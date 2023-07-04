<template>
  <q-layout
    container
    class="bg-white"
    style="width: 1300px; max-width: 150vw; max-height: 700px"
  >
    <q-page class="q-pa-lg">
      <div class="text-h5 q-pt-sm" style="color: blak">
        {{ !editOrSave ? "Add grain info" : "Change grain info" }}
      </div>
      <q-form @reset="reset()" @submit="editOrSave ? editGrain() : saveGrain()">
        <div class="row">
          <div class="col q-pt-md q-mr-sm">
            <q-input
              v-model="RecordDate"
              type="date"
              class="q-pt-md"
              filled
              label="RecordDate"
              lazy-rules
              :rules="[(val) => RecordDate.length > 0 || 'Required']"
            >
            </q-input>

            <div class="row">
              <div class="col q-pr-md">
                <q-input
                  v-model="BranchId"
                  class="q-pt-md"
                  type="number"
                  filled
                  label="BranchId"
                  lazy-rules
                  :rules="[BranchId != null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="BranchId !== null"
                      name="close"
                      @click="this.BranchId = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
              <div class="col">
                <q-select
                  v-model="CropYear"
                  :options="YearOptions"
                  class="q-pt-md"
                  filled
                  label="CropYear"
                  lazy-rules
                  :rules="[CropYear !== '' || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="CropYear !== ''"
                      name="close"
                      @click="this.CropYear = ''"
                      class="cursor-pointer"
                    />
                  </template>
                </q-select>
              </div>
            </div>
            <div class="row">
              <div class="col q-pr-md">
                <q-input
                  type="number"
                  v-model="CounterpartyId"
                  class="q-pt-md"
                  filled
                  label="CounterpartyId"
                  lazy-rules
                  :rules="[CounterpartyId !== null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="CounterpartyId !== null"
                      name="close"
                      @click="this.CounterpartyId = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
              <div class="col">
                <q-input
                  v-model="CounterpartyName"
                  class="q-pt-md"
                  filled
                  label="CounterpartyName"
                  lazy-rules
                  :rules="[CounterpartyName !== '' || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="CounterpartyName !== ''"
                      name="close"
                      @click="this.CounterpartyName = ''"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
            </div>
            <div class="row">
              <div class="col q-pr-md">
                <q-input
                  type="number"
                  v-model="ContractId"
                  class="q-pt-md"
                  filled
                  label="ContractId"
                  lazy-rules
                  :rules="[ContractId !== null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="ContractId !== null"
                      name="close"
                      @click="this.ContractId = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
              <div class="col">
                <q-input
                  v-model="Product"
                  class="q-pt-md"
                  filled
                  label="Product"
                  lazy-rules
                  :rules="[Product !== '' || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="Product !== ''"
                      name="close"
                      @click="this.Product = ''"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
            </div>
          </div>
          <div class="col q-pt-md q-ml-md">
            <div class="row">
              <div class="col q-pr-md">
                <q-input
                  v-model="Price"
                  class="q-pt-md"
                  filled
                  label="Price"
                  lazy-rules
                  :rules="[Price !== null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="Price !== null"
                      name="close"
                      @click="this.Price = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
              <div class="col">
                <q-input
                  v-model="Amount"
                  type="number"
                  class="q-pt-md"
                  filled
                  label="Amount"
                  lazy-rules
                  :rules="[Amount !== null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="Amount !== null"
                      name="close"
                      @click="Amount = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
            </div>
            <div class="row">
              <div class="col q-pr-md">
                <q-select
                  v-model="Process"
                  class="q-pt-md"
                  filled
                  label="Process"
                  :options="processOptions"
                  lazy-rules
                  :rules="[Process !== '' || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="Process !== ''"
                      name="close"
                      @click="this.Process = ''"
                      class="cursor-pointer"
                    />
                  </template>
                </q-select>
              </div>
              <div class="col">
                <q-input
                  v-model="Wetness"
                  class="q-pt-md"
                  filled
                  label="Wetness"
                  lazy-rules
                  :rules="[Wetness !== null || 'Required']"
                >
                  <template v-slot:append>
                    <q-icon
                      v-if="Wetness !== null"
                      name="close"
                      @click="Wetness = null"
                      class="cursor-pointer"
                    />
                  </template>
                </q-input>
              </div>
            </div>
            <q-input
              v-model="Garbage"
              class="q-pt-md"
              filled
              label="Garbage"
              lazy-rules
              :rules="[Garbage !== '' || 'Required']"
            >
              <template v-slot:append>
                <q-icon
                  v-if="Garbage !== ''"
                  name="close"
                  @click="Garbage = ''"
                  class="cursor-pointer"
                />
              </template>
            </q-input>
            <q-select
              class="q-pt-md"
              filled
              label="Infection"
              v-model="Infection"
              use-input
              hide-selected
              fill-input
              input-debounce="0"
              :options="infectionOptions"
              @input-value="(val) => (this.Infection = val)"
            >
              <template v-slot:append>
                <q-icon
                  v-if="Infection !== ''"
                  name="close"
                  @click="this.Infection = ''"
                  class="cursor-pointer"
                />
              </template>
            </q-select>
          </div>
        </div>
        <div class="q-pt-xl row">
          <div class="q-pr-xs col">
            <q-btn
              label="Reset"
              type="reset"
              color="primary"
              flat
              class="q-ml-sm"
            />
          </div>
          <div class="col-md-3 offset-md-3 col-lg-2 offset-lg-2">
            <q-btn
              :label="editOrSave ? 'Apply' : 'Submit'"
              type="submit"
              color="primary"
            />
          </div>
        </div>
      </q-form>
    </q-page>
  </q-layout>
</template>
<script>
import grainApi from "../api_connections/grainApi";
import { format } from "https://cdn.skypack.dev/date-fns@2.29.3";
export default {
  props: {
    grainEditInfo: null,
    editOrSaveProp: null,
  },
  data() {
    return {
      Api: new grainApi(),
      Id: null,
      RecordDate: null,
      BranchId: null,
      CropYear: "",
      CounterpartyId: null,
      CounterpartyName: "",
      ContractId: null,
      Product: "",
      Price: null,
      Amount: null,
      Process: "",
      Wetness: null,
      Garbage: "",
      Infection: "",
      editOrsave: false,
      warn: "",
      YearOptions: [
        "2019",
        "2020",
        "2021",
        "2022",
        "2023",
        "2024",
        "2025",
        "2026",
        "2027",
        "2028",
      ],
      processOptions: ["ПРИХІД", "переміщення"],
      infectionOptions: ["н-обн."],
    };
  },

  methods: {
    reset() {
      this.Id = null;
      this.RecordDate = null;
      this.BranchId = null;
      this.CropYear = "";
      this.CounterpartyId = null;
      this.CounterpartyName = "";
      this.ContractId = null;
      this.Product = "";
      this.Price = null;
      this.Amount = null;
      this.Process = "";
      this.Wetness = null;
      this.Garbage = "";
      this.Infection = "";
      this.editOrsave = false;
      this.warn = "";
    },
    async saveGrain() {
      await this.Api.SaveGrainInfo(
        this.RecordDate,
        this.BranchId,
        this.CropYear,
        this.CounterpartyId,
        this.CounterpartyName,
        this.ContractId,
        this.Product,
        this.Price,
        this.Amount,
        this.Process,
        this.Wetness,
        this.Garbage,
        this.Infection
      );
      this.$emit("addGrain");
      this.editOrsave = false;
      this.$props.editOrSave = false;
    },
    async editGrain() {
      await this.Api.EditGrainInfo(
        this.Id,
        this.RecordDate,
        this.BranchId,
        this.CropYear,
        this.CounterpartyId,
        this.CounterpartyName,
        this.ContractId,
        this.Product,
        this.Price,
        this.Amount,
        this.Process,
        this.Wetness,
        this.Garbage,
        this.Infection
      );
      this.$emit("addGrain");
      this.$props.editOrSave = false;
    },
  },

  mounted() {
    debugger;
    this.editOrSave = this.$props.editOrSaveProp;
    if (this.editOrSave == true) {
      this.Id = this.$props.grainEditInfo.id;
      this.RecordDate = format(
        new Date(this.$props.grainEditInfo.recordDate),
        "yyyy-MM-dd"
      );
      this.BranchId = this.$props.grainEditInfo.branchId;
      this.CropYear = this.$props.grainEditInfo.cropYear;
      this.CounterpartyId = this.$props.grainEditInfo.counterpartyId;
      this.CounterpartyName = this.$props.grainEditInfo.counterpartyName;
      this.ContractId = this.$props.grainEditInfo.contractId;
      this.Product = this.$props.grainEditInfo.product;
      this.Price = this.$props.grainEditInfo.price;
      this.Amount = this.$props.grainEditInfo.amount;
      this.Process = this.$props.grainEditInfo.process;
      this.Wetness = this.$props.grainEditInfo.wetness;
      this.Garbage = this.$props.grainEditInfo.garbage;
      this.Infection = this.$props.grainEditInfo.infection;
    }
  },
};
</script>
