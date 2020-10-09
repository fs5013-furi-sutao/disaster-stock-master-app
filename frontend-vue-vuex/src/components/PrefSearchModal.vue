<template>
  <transition name="modal">
    <div id="overlay" v-show="showContent" @click="closeModal">
      <div class="modal-container" @click="stopEvent">
        <h3>県コード検索</h3>
        <p class="px-3">県名を入力してください。</p>
        
        <div class="form-row mt-3">
          <div class="form-group col-md-9 px-3">
            <label for="pref-search"
              >県名<span class="text-black-50">（部分一致）</span></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="pref-search"
                placeholder="県名を入力してください"
                v-model="search.name"
              />
              <span class="input-group-btn ml-3">
                <button
                  type="submit"
                  class="btn btn-primary px-5"
                  @click.prevent="searchPrefs"
                >
                  <font-awesome-icon icon="search" />検索
                </button>
              </span>
            </div>
          </div>
        </div>

        <table class="table table-hover">
          <thead>
            <tr>
              <th scope="col" style="width: 8em;">
                <i class="calendar plus icon"></i>県コード
              </th>
              <th scope="col" style="width: 20em;">
                <i class="info circle icon"></i>県名
              </th>
              <th scope="col" style="width: 6em;">
                <font-awesome-icon icon="edit" />
              </th>
            </tr>
          </thead>
          <tr v-for="(pref, i) in prefs" :key="i">
            <td>{{ pref.cd }}</td>
            <td>{{ pref.name }}</td>
            <td class="center aligned">
              <button
                type="submit"
                class="btn btn-info"
                @click="onSelect(pref)"
              >
                選択
              </button>
            </td>
          </tr>
        </table>
      </div>
    </div>
  </transition>
</template>

<script>
import { api } from '../services/api.service';
export default {
  props: {
    search: {
      type: Object,
      required: false,
      default: () => {
        return {
          name: ''
        };
      }
    },
    pref: {
      type: Object,
      required: false,
      default: () => {
        return {
          id: '',
          cd: '',
          name: '',
        };
      }
    }
  },
  data() {
    return {
      prefs: [],
      prefJson: [],
      showContent: false,
      errorNoResults: false
    };
  },
  methods: {
    isNoSearchResults: function(value) {
      if (value == 0) {
        this.errorNoResults = true;
        return true;
      }
      this.errorNoResults = false;
      return false;
    },
    openModal: function() {
      this.showContent = true;
    },
    closeModal: function() {
      this.showContent = false;
    },
    stopEvent: function() {
      event.stopPropagation();
    },
    onSelect: function(pref) {
      this.$parent.disasterStock.prefCd = pref.cd;
      this.$parent.disasterStock.prefName = pref.name;
      this.showContent = false;
    },
    async searchPrefs() {
      this.prefs = [];
      this.prefs = await api.getPrefsByName(this.search.name);

      if (this.isNoSearchResults(this.prefs)) return;

      // for (const [, v] of this.prefJson.entries()) {
      //   let manufacture = await api.getManufactureByCd(v['manufactureCd']);
      //   this.products.push({
      //     id: v['id'],
      //     cd: v['cd'],
      //     name: v['name'],
      //     volume: v['volume'],
      //     manufactureCd: manufacture.cd,
      //     manufactureName: manufacture.name
      //   });
      // }
    }
  }
};
</script>
