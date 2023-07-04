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
        </template>
      </q-table>
    </div>
  </div>
</template>

<script>
const columns = [
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
  },
];

import { ref } from "vue";
import grainApi from "../api_connections/grainApi";

export default {
  props: {
    selectedClMode: [],
  },
  data() {
    return {
      Api: new grainApi(),
      JsonFile: ref(null),
      grainData: [],
      pggG: {
        rowsPerPage: 5,
        page: 1,
        rowsNumber: 10,
      },
    };
  },
  setup() {
    return {
      columns,
    };
  },
  methods: {
    async getGrainData() {
      debugger;
      this.grainData = [];
      this.pggG.rowsNumber = await this.Api.MergeDataGroupsCount();
      var gd = await this.Api.GetDataMerged(
        this.$props.selectedClMode,
        this.pggG.rowsPerPage,
        this.pggG.page
      );
      gd.forEach((el) => {
        this.grainData.push(el);
      });
    },
    async paginationHandle(props) {
      this.pggG.page = props.pagination.page;
      this.pggG.rowsPerPage = props.pagination.rowsPerPage;
      await this.getGrainData();
    },
  },
  mounted() {
    this.getGrainData();
  },
};
</script>
