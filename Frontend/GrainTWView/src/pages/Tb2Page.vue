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
      >
        <template v-slot:top>
          <q-space />
          <q-btn
            class="q-pa-md q-mb-md q-mr-xl"
            outline
            color="blue"
            label='Export in "Merged"'
            icon-right="send"
            style="width: 15%"
            v-if="
              this.selectedClMode.find((d) => true) != null &&
              this.gropeByMode == false &&
              showExportButton == true
            "
            @click="exportInMergedClick()"
          />
          <q-btn
            class="q-pa-md q-mb-md q-mr-xl"
            outline
            color="green"
            label="GROUP BY"
            style="width: 10%"
            @click="groupByClick()"
          />
        </template>
        <template v-slot:header-cell-RecordDate="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-BranchId="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-CropYear="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-CounterpartyId="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-CounterpartyName="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-ContractId="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Product="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Price="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Amount="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Process="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Wetness="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Garbage="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
        <template v-slot:header-cell-Infection="props">
          <q-th
            :props="props"
            @click="selectColumnClick(props)"
            :style="
              gropeByMode == true &&
              selectedClMode.find((d) => d == props.col.name) == null
                ? 'background-color: rgb(198, 198, 198); cursor: pointer'
                : selectedClMode.find((d) => d == props.col.name) != null &&
                  this.gropeByMode == true
                ? 'background-color: rgb(91, 178, 132); cursor: pointer'
                : ''
            "
          >
            <q-avatar size="20px" v-if="gropeByMode == true">
              <img
                src="https://cdn-icons-png.flaticon.com/512/892/892498.png"
              />
            </q-avatar>
            {{ props.col.label }}
          </q-th>
        </template>
      </q-table>
    </div>
  </div>
</template>

<script>
const columns = [
  {
    name: "Id",
    field: "id",
    required: true,
    label: "Record number",
    align: "left",
    sortable: false,
  },
  {
    name: "RecordDate",
    field: "recordDate",
    align: "center",
    label: "Record date",
    sortable: false,
  },
  {
    name: "BranchId",
    field: "branchId",
    align: "center",
    label: "Subdivision-Code",
    sortable: false,
  },
  {
    name: "CropYear",
    field: "cropYear",
    align: "center",
    label: "Harvest year",
    sortable: false,
  },
  {
    name: "CounterpartyId",
    field: "counterpartyId",
    align: "center",
    label: "counterparty",
    sortable: false,
  },
  {
    name: "CounterpartyName",
    field: "counterpartyName",
    align: "left",
    label: "Name",
    sortable: false,
  },
  {
    name: "ContractId",
    field: "contractId",
    align: "center",
    label: "Unique" + "\n" + "contract\nnumber",
    sortable: false,
  },
  {
    name: "Product",
    field: "product",
    align: "center",
    label: "TMC-Code",
    sortable: false,
  },
  {
    name: "Price",
    field: "price",
    label: "Price",
    sortable: false,
  },
  {
    name: "Amount",
    field: "amount",
    align: "center",
    label: "Net quantity",
    sortable: false,
  },
  {
    name: "Process",
    field: "process",
    align: "center",
    label: "Direction",
    sortable: false,
  },
  {
    name: "Wetness",
    field: "wetness",
    align: "center",
    label: "humidity",
    sortable: false,
  },
  {
    name: "Garbage",
    field: "garbage",
    align: "center",
    label: "garbage",
    sortable: false,
  },
  {
    name: "Infection",
    field: "infection",
    align: "center",
    label: "infection",
    sortable: false,
    style: " ",
  },
];

import { ref } from "vue";
import grainApi from "../api_connections/grainApi";
const sleep = (ms) => {
  return new Promise((resolve) => setTimeout(resolve, ms));
};

export default {
  props: {
    selectedClModeProp: [],
  },
  data() {
    return {
      columns,
      Api: new grainApi(),
      grainData: [],
      pggG: {
        sortBy: "",
        descending: false,
        rowsPerPage: 5,
        page: 1,
        rowsNumber: 10,
      },
      gropeByMode: false,
      selectedClMode: [],
      showExportButton: false,
    };
  },
  setup() {
    return {};
  },
  methods: {
    async getGrainData() {
      this.grainData = [];
      this.pggG.rowsNumber = await this.Api.getGrainDataCount();
      var gd = await this.Api.getGrainDataGroups(
        this.selectedClMode,
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
    async groupByClick() {
      if (this.gropeByMode == true) {
        this.gropeByMode = false;
        var i = 0;
        this.columns.forEach((el) => {
          this.columns[i].style = "";
          if (this.selectedClMode.find((d) => d == el.name) != null) {
            this.columns[i].style = "background-color: rgb(91, 178, 132);";
          }
          i = i + 1;
        });
        this.showExportButton = true;
        await this.getGrainData();
      } else {
        this.gropeByMode = true;
      }
    },
    selectColumnClick(props) {
      if (this.gropeByMode == true) {
        if (this.selectedClMode.find((d) => d == props.col.name) != null) {
          this.selectedClMode.splice(
            this.selectedClMode.indexOf(props.col.name),
            1
          );
        } else {
          this.selectedClMode.push(props.col.name);
        }
      }
    },
    exportInMergedClick() {
      debugger;
      this.showExportButton = false;
      this.$emit("exportClick");
    },
  },
  mounted() {
    this.selectedClMode = this.$props.selectedClModeProp;
    var i = 0;
    this.columns.forEach((el) => {
      this.columns[i].style = "background-color: white";
      if (this.selectedClMode.find((d) => d == el.name) != null) {
        this.columns[i].style = "background-color: rgb(91, 178, 132);";
      }
      i = i + 1;
    });
    this.getGrainData();
  },
};
</script>
