<template>
  <transition name="modal">
    <div id="overlay" v-show="showContent" @click="closeModal">
      <div class="modal-container" @click="stopEvent">
        <h3>商品検索</h3>
        <p class="px-3">商品名を入力してください。</p>

        <!-- 商品コード・商品名 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-9 px-3">
            <label for="product-code"
              >商品名<span class="text-black-50">（部分一致）</span></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="product-search"
                placeholder="商品を入力してください"
                v-model="search.name"
              />
              <span class="input-group-btn ml-3">
                <button
                  type="submit"
                  class="btn btn-primary px-5"
                  @click.prevent="searchProducts"
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
                <i class="calendar plus icon"></i>商品コード
              </th>
              <th scope="col" style="width: 20em;">
                <i class="info circle icon"></i>商品名
              </th>
              <th><i class="info circle icon"></i>容量</th>
              <th><i class="info circle icon"></i>メーカー</th>
              <th scope="col" style="width: 6em;">
                <font-awesome-icon icon="edit" />
              </th>
            </tr>
          </thead>
          <tr v-for="(product, i) in products" :key="i">
            <td>{{ product.cd }}</td>
            <td>{{ product.name }}</td>
            <td>{{ product.volume }}</td>
            <td>{{ product.manufactureName }}</td>
            <td class="center aligned">
              <button
                type="submit"
                class="btn btn-info"
                @click="onSelect(product)"
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
    product: {
      type: Object,
      required: false,
      default: () => {
        return {
          id: '',
          cd: '',
          name: '',
          volume: '',
          manufactureCd: '',
          manufactureName: '',
          createdAt: '',
          createdUserId: '',
          updatedAt: '',
          updatedUserId: ''
        };
      }
    }
  },
  data() {
    return {
      products: [],
      productJson: [],
      // product: {
      //   id: '',
      //   cd: '',
      //   name: '',
      //   volume: '',
      //   manufactureCd: '',
      //   createdAt: '',
      //   createdUserId: '',
      //   updatedAt: '',
      //   updatedUserId: ''
      // },
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
    onSelect: function(product) {
      this.$parent.product.id = product.id;
      this.$parent.product.cd = product.cd;
      this.$parent.product.name = product.name;
      this.$parent.product.volume = product.volume;
      this.$parent.product.manufactureCd = product.manufactureCd;
      this.$parent.product.manufactureName = product.manufactureName;
      this.showContent = false;
    },
    async searchProducts() {
      this.products = [];
      this.productJson = await api.getProductsByName(this.search.name);

      if (this.isNoSearchResults(this.productJson)) return;

      for (const [, v] of this.productJson.entries()) {
        let manufacture = await api.getManufactureByCd(v['manufactureCd']);
        this.products.push({
          id: v['id'],
          cd: v['cd'],
          name: v['name'],
          volume: v['volume'],
          manufactureCd: manufacture.cd,
          manufactureName: manufacture.name
        });
      }
    }
  }
};
</script>
