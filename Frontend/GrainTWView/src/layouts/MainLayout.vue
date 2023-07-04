<template>
  <div>
    <q-layout view="hHh lpR fFf">
      <q-header bordered class="bg-grey-3 text-primary">
        <q-toolbar>
          <q-toolbar-title class="text-center">
            <q-avatar>
              <img
                src="https://ventalab.ua/content/uploads/images/yak-viznachiti-yakist-zerna-pshenitsi-65688825245696_db720dc734.jpg"
              />
            </q-avatar>
            Grain accounting
          </q-toolbar-title>
        </q-toolbar>
      </q-header>

      <q-footer bordered class="bg-grey-3 text-primary">
        <q-tabs
          no-caps
          active-color="primary"
          indicator-color="transparent"
          class="text-grey-8"
          v-model="tab"
        >
          <q-tab name="table1" label="Grain receipts" @click="TbClick('tb1')" />
          <q-tab name="table2" label="Grouped" @click="TbClick('tb2')" />
          <q-tab
            name="table3"
            label="Merged"
            @click="TbClick('tb3')"
            v-if="this.showPg3 == true"
          />
        </q-tabs>
      </q-footer>

      <q-page-container>
        <GrainPage
          ref="GP"
          @showPg3="showPg3Handle()"
          @closePg3="closePg3Handle()"
          @addGrainH="addGrainR()"
        />
      </q-page-container>
    </q-layout>
  </div>
</template>

<script>
import { ref } from "vue";
import GrainPage from "src/pages/GrainPage.vue";
export default {
  components: { GrainPage },
  data() {
    return {
      nameTab: "",
      showPg3: false,
    };
  },
  setup() {
    return {
      tab: ref("table1"),
    };
  },
  methods: {
    TbClick(clicked) {
      this.$refs.GP.changeNavTable(clicked);
    },
    showPg3Handle() {
      debugger;
      this.showPg3 = true;
    },
    closePg3Handle() {
      this.showPg3 = false;
    },
    addGrainR() {
      this.showPg3 = false;
    },
  },
};
</script>
