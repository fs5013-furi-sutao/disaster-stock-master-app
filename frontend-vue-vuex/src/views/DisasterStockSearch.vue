<template>
  <div class="container">
    <header class="pt-3 pb-2">
      <h3 class="">災害備蓄マスタ検索</h3>
    </header>
    <main>
      <form>
        <!-- 商品コード・商品名 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="product-code">商品コード</label>
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="product-code"
                v-model="product.cd"
                readonly
              />
              <span class="input-group-btn ml-3">
                <button
                  type="submit"
                  class="btn btn-info"
                  @click.prevent="openProductSearchModal"
                >
                  選択
                </button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="product-name">商品名</label>
            <input
              type="text"
              class="form-control"
              id="product-name"
              v-model="product.name"
              readonly
            />
          </div>
        </div>

        <!-- 単位容量・メーカー名 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="product-volume">単位・容量</label>
            <input
              type="text"
              class="form-control"
              id="product-volume"
              v-model="product.volume"
              readonly
            />
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="product-manufacture">メーカー名</label>
            <input
              type="text"
              class="form-control"
              id="product-manufacture"
              v-model="product.manufactureName"
              readonly
            />
          </div>
        </div>

        <!-- 備蓄保持区分・備蓄条件区分・県コード -->
        <div class="form-row mt-3">
          <div class="form-group col-md-3 px-3">
            <label for="saving-stock-kbn">備蓄保持区分</label>
            <!-- <select class="form-control" id="pref-cd" name="pref-cd">
              <option value="1">1</option>
              <option value="2" selected="selected">2</option>
              <option value="3">3</option>
            </select> -->
            <select
              class="form-control"
              v-model="searchCondition.savingStockKbn"
            >
              <option value hidden></option>
              <option
                syle="color: black;"
                v-for="kbn in savingStockKbnOptions"
                :key="kbn.id"
                :value="kbn.id"
              >
                {{ kbn.cdAndValue }}
              </option>
            </select>
          </div>
        </div>

        <!-- 備蓄開始日・備蓄終了日 -->
        <div class="form-row mt-3 mb-5">
          <div class="form-group col-md-6 px-3">
            <label for="stock-start-date">備蓄開始日</label>
            <input
              type="date"
              class="form-control"
              id="stock-start-date"
              v-model="searchCondition.stockStartDate"
            />
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="stock-end-date">備蓄終了日</label>
            <input
              type="date"
              class="form-control"
              id="stock-end-date"
              v-model="searchCondition.stockEndDate"
            />
          </div>
        </div>

        <div class="input-group px-3 mb-5">
          <button
            type="submit"
            class="btn btn-primary btn-lg px-5 mr-5"
            @click.prevent="onSearchDisasterStock"
          >
            <font-awesome-icon icon="search" /><span class="px-2">検索</span>
          </button>
          <button type="submit" class="btn btn-primary btn-lg px-5">
            新規登録
          </button>
        </div>
      </form>

      <table class="table table-responsive-sm table-hover">
        <thead>
          <tr>
            <th scope="col" style="width:2em;">No.</th>
            <th scope="col" style="width:6em;">&nbsp;</th>
            <th scope="col">商品名</th>
            <th scope="col">数量</th>
            <th scope="col">備蓄保持区分</th>
            <th scope="col">県名</th>
            <th scope="col">不足時入荷支店名</th>
          </tr>
        </thead>
        <tbody>
          <tr>

          </tr>
        </tbody>
      </table>

      <ProductSearchModal ref="productSearchModal" />
    </main>
  </div>
</template>

<script>
import { api } from '../services/api.service';
import ProductSearchModal from '@/components/ProductSearchModal';
export default {
  name: 'DisasterStockSearch',
  components: {
    ProductSearchModal
  },
  props: {
    savingStockKbn: {
      type: Object,
      required: false,
      default: () => {
        return {
          id: '',
          kbn: '',
          cd: '',
          value: '',
          cdAndValue: ''
        };
      }
    },
    searchCondition: {
      type: Object,
      required: false,
      default: () => {
        return {
          productCd: '',
          savingStockKbn: '',
          stockStartDate: '',
          stockEndDate: ''
        };
      }
    },
    disasterStock: {
      id: '',
      productCd: '',
      productName: '',
      savingStockKbn: '',
      prefCd: '',
      prefName: '',
      branchCd: '',
      branchName: '',
      quantity: '',
      stockStartDate: '',
      stockEndDate: '',
      reserveBranchCd: '',
      stockConditionKbn: '',
      Version: ''
    }
  },
  data() {
    return {
      product: {
        id: '',
        cd: '',
        name: '',
        volume: '',
        manufactureCd: '',
        manufactureName: ''
      },
      disasterStocks: [],
      savingStockKbns: [],
      savingStockKbnOptions: []
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  async mounted() {
    if (!this.currentUser) {
      this.$router.push('/login');
    }

    this.savingStockKbnOptions = [];
    this.savingStockKbns = await api.getSavingStockKbn();

    for (const [, v] of this.savingStockKbns.entries()) {
      this.savingStockKbnOptions.push({
        id: v['id'],
        cdAndValue: `${v['cd']}: ${v['value']}`
      });
    }
  },
  methods: {
    openProductSearchModal: function() {
      this.$refs.productSearchModal.openModal();
    },
    async onSearchDisasterStock() {
      const savingStockKbn = this.searchCondition.savingStockKbn;
      const stockStartDate = this.searchCondition.stockStartDate;
      const stockEndDate = this.searchCondition.stockEndDate;
      this.searchCondition = {};
      this.searchCondition.productCd = this.product.cd;
      this.searchCondition.savingStockKbns = savingStockKbn;
      this.searchCondition.stockStartDate = stockStartDate;
      this.searchCondition.stockEndDate = stockEndDate;
      this.disasterStocks = await api.getDisasterStocksBySearchConditions(this.searchCondition);
      console.log(this.disasterStocks);
    }
  }
};
</script>
