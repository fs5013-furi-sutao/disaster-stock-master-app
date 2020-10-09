<template>
  <transition name="modal">
    <div id="overlay" v-show="showContent" @click="closeModal">
      <div class="modal-container" @click="stopEvent">
        <h3>{{ operationDataName }}検索</h3>
        <p class="px-3">支店名を入力してください。</p>

        <div class="form-row mt-3">
          <div class="form-group col-md-9 px-3">
            <label for="branch-search"
              >{{ operationDataName }}名<span class="text-black-50"
                >（部分一致）</span
              ></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="branch-search"
                placeholder="支店を入力してください"
                v-model="search.name"
              />
              <span class="input-group-btn ml-3">
                <button
                  type="submit"
                  class="btn btn-primary px-5"
                  @click.prevent="searchBranches"
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
                <i class="calendar plus icon"></i>支店コード
              </th>
              <th scope="col">
                支店名
              </th>
              <th>県コード</th>
              <th>県名</th>
              <th scope="col" style="width: 6em;">
                <font-awesome-icon icon="edit" />
              </th>
            </tr>
          </thead>
          <tr v-for="(branch, i) in branches" :key="i">
            <td>{{ branch.cd }}</td>
            <td>{{ branch.name }}</td>
            <td>{{ branch.prefCd }}</td>
            <td>{{ branch.prefName }}</td>
            <td class="center aligned">
              <button
                type="submit"
                class="btn btn-info"
                @click="onSelect(branch)"
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
    branch: {
      type: Object,
      required: false,
      default: () => {
        return {
          id: '',
          cd: '',
          name: '',
          prefCd: '',
          prefName: ''
        };
      }
    }
  },
  data() {
    return {
      branches: [],
      branchJson: [],
      operationDataType: '',
      operationDataName: '',
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
    openModal: function(operationDataType) {
      this.showContent = true;
      this.operationDataType = operationDataType;

      if (operationDataType == 'branch') {
        this.operationDataName = '支店';
        return;
      }
      this.operationDataName = '不足時入荷支店';
    },
    closeModal: function() {
      this.showContent = false;
    },
    stopEvent: function() {
      event.stopPropagation();
    },
    onSelect: function(branch) {
      if (this.operationDataType == 'branch') {
        this.$parent.disasterStock.branchCd = branch.cd;
        this.$parent.disasterStock.branchName = branch.name + '支店';
      }
      if (this.operationDataType == 'reserveBranch') {
        this.$parent.disasterStock.reserveBranchCd = branch.cd;
        this.$parent.disasterStock.reserveBranchName = branch.name + '支店';
      }
      this.showContent = false;
    },
    async searchBranches() {
      this.branches = [];
      this.branchJson = await api.getBranchesByName(this.search.name);

      if (this.isNoSearchResults(this.branchJson)) return;

      for (const [, v] of this.branchJson.entries()) {
        let pref = await api.getPrefByCd(v['prefCd']);
        this.branches.push({
          id: v['id'],
          cd: v['cd'],
          name: v['name'],
          prefCd: pref.cd,
          prefName: pref.name
        });
      }
    }
  }
};
</script>
