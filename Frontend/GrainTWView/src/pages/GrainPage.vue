<template>
  <q-page>
    <tb-1-page v-if="curentTable == 'tb1'" @addGrainL="addGrainHandle()" />
    <tb-2-page
      v-if="curentTable == 'tb2'"
      v-model:selectedClMode="selectedClMode"
      :selectedClModeProp="selectedClMode"
      @exportClick="exportClickHandle()"
    />
    <tb-3-page
      :selectedClMode="selectedClMode"
      v-if="curentTable == 'tb3'"
    ></tb-3-page>
  </q-page>
</template>

<script>
import Tb1Page from "./Tb1Page.vue";
import Tb2Page from "./Tb2Page.vue";
import Tb3Page from "./Tb3Page.vue";
export default {
  components: { Tb1Page, Tb2Page, Tb3Page },
  data() {
    return {
      curentTable: "tb1",
      selectedClMode: [],
    };
  },
  methods: {
    changeNavTable(nameNavTab) {
      this.curentTable = nameNavTab;
    },
    exportClickHandle() {
      debugger;
      this.$emit("showPg3");
    },
    addGrainHandle() {
      this.$emit("addGrainH");
    },
  },
  watch: {
    selectedClMode: {
      handler: function (after, before) {
        this.$emit("closePg3");
      },
      deep: true,
    },
  },
};
</script>
