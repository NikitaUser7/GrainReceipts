<template>
  <div class="column">
    <div class="col">
      <q-table
        :rows="grainData"
        :columns="columns"
        row-key="id"
        ref="grainTable"
        v-model:pagination="pggG"
        @request="(requestProp) => paginationHandle(requestProp)"
        selection="multiple"
        v-model:selected="selectedRows"
      >
        <template v-slot:top>
          <q-space />
          <div class="q-pa-md q-gutter-sm">
            <q-btn
              outline
              color="yellow"
              label="Edit"
              @click="editGrainClick()"
              size="lg"
              v-if="selectedRows.length == 1"
            />
            <q-btn
              outline
              color="blue"
              label="+ Add new"
              size="lg"
              v-if="selectedRows.length < 1"
              @click="addGrainClick()"
            />
            <q-btn
              outline
              color="grey"
              label="CLEAR SELECT"
              size="lg"
              v-if="selectedRows.length > 0"
              @click="clearSelect()"
            />
            <q-btn
              outline
              color="red"
              label="DELETE"
              size="lg"
              @click="deleteGrainData"
              v-if="selectedRows.length > 0"
            />
          </div>

          <q-file
            class="col-2 q-ma-sm"
            filled
            bottom-slots
            v-model="JsonFile"
            label="JSON"
            counter
            max-files="150"
            hint="Upload .json"
          >
            <template v-slot:append>
              <q-icon
                v-if="JsonFile !== null"
                name="close"
                @click.stop.prevent="JsonFile = null"
                class="cursor-pointer"
              />
              <q-icon name="create_new_folder" />
            </template>

            <template v-slot:after>
              <q-btn round dense flat icon="send" @click="sendJsonFile()" />
            </template>
          </q-file>
        </template>
      </q-table>
    </div>
  </div>
  <q-dialog v-model="showDialog">
    <add-dialog
      :grainEditInfo="selectedRows[0]"
      :editOrSaveProp="editOrSaveVar"
      @addGrain="addGrain()"
    ></add-dialog>
  </q-dialog>
</template>

<script>
const columns = [
  {
    name: "Id",
    field: "id",
    required: true,
    label: "Record number",
    align: "left",
    sortable: true,
  },
  {
    name: "RecordDate",
    field: "recordDate",
    align: "center",
    label: "Record date",
    sortable: true,
  },
  {
    name: "BranchId",
    field: "branchId",
    align: "center",
    label: "Subdivision-Code",
    sortable: true,
  },
  {
    name: "CropYear",
    field: "cropYear",
    align: "center",
    label: "Harvest year",
    sortable: true,
  },
  {
    name: "CounterpartyId",
    field: "counterpartyId",
    align: "center",
    label: "counterparty",
    sortable: true,
  },
  {
    name: "CounterpartyName",
    field: "counterpartyName",
    align: "left",
    label: "Name",
    sortable: true,
  },
  {
    name: "ContractId",
    field: "contractId",
    align: "center",
    label: "Unique" + "\n" + "contract\nnumber",
    sortable: true,
  },
  {
    name: "Product",
    field: "product",
    align: "center",
    label: "TMC-Code",
    sortable: true,
  },
  {
    name: "Price",
    field: "price",
    label: "Price",
    sortable: true,
  },
  {
    name: "Amount",
    field: "amount",
    align: "center",
    label: "Net quantity",
    sortable: true,
  },
  {
    name: "Process",
    field: "process",
    align: "center",
    label: "Direction",
    sortable: true,
  },
  {
    name: "Wetness",
    field: "wetness",
    align: "center",
    label: "humidity",
    sortable: true,
  },
  {
    name: "Garbage",
    field: "garbage",
    align: "center",
    label: "garbage",
    sortable: true,
  },
  {
    name: "Infection",
    field: "infection",
    align: "center",
    label: "infection",
    sortable: true,
  },
];

import { ref } from "vue";
import grainApi from "../api_connections/grainApi";
import AddDialog from "./AddDialog.vue";
const sleep = (ms) => {
  return new Promise((resolve) => setTimeout(resolve, ms));
};

export default {
  components: { AddDialog },
  data() {
    return {
      Api: new grainApi(),
      JsonFile: ref(null),
      grainData: [],
      pggG: {
        sortBy: "",
        descending: false,
        rowsPerPage: 5,
        page: 1,
        rowsNumber: 10,
      },
      selectedRows: [],
      selectedIds: [],
      showDialog: false,
      editOrSaveVar: false,
    };
  },
  setup() {
    return {
      columns,
    };
  },
  methods: {
    async sendJsonFile() {
      await this.Api.sendJsonFile(this.JsonFile);
      sleep(1000).then(() => {
        this.getGrainData();
      });

      this.JsonFile = null;
    },
    clearInputJson() {
      this.JsonFile = null;
    },
    async getGrainData() {
      this.grainData = [];
      this.pggG.rowsNumber = await this.Api.getGrainDataCount();
      var gd = await this.Api.getGrainData(
        this.pggG.sortBy,
        this.pggG.descending,
        this.pggG.rowsPerPage,
        this.pggG.page
      );
      gd.forEach((el) => {
        this.grainData.push(el);
      });
    },
    async paginationHandle(props) {
      this.pggG.sortBy = props.pagination.sortBy;
      this.pggG.descending = props.pagination.descending;
      this.pggG.page = props.pagination.page;
      this.pggG.rowsPerPage = props.pagination.rowsPerPage;
      await this.getGrainData();
    },
    async deleteGrainData() {
      this.$emit("addGrainL");
      this.selectedRows.forEach((el) => {
        if (el.id != undefined) {
          this.selectedIds.push(el.id);
        }
      });
      await this.Api.deleteGrainData(this.selectedIds);
      await this.getGrainData();
      this.selectedRows = [{}];
      this.selectedIds = [];
      this.pggG = {
        sortBy: "",
        descending: false,
        rowsPerPage: 5,
        page: 1,
        rowsNumber: await this.Api.getGrainDataCount(),
      };
      this.selectedRows = [];
      this.selectedIds = [];
    },
    clearSelect() {
      this.selectedRows = [];
      this.selectedIds = [];
    },
    addGrainClick() {
      this.showDialog = true;
      this.editOrSaveVar = false;
    },
    editGrainClick() {
      this.editOrSaveVar = true;
      this.showDialog = true;
    },
    async addGrain() {
      this.$emit("addGrainL");
      this.selectedRows = [];
      this.selectedIds = [];
      this.showDialog = false;
      await this.getGrainData();
    },
  },
  mounted() {
    this.getGrainData();
  },
};
</script>
