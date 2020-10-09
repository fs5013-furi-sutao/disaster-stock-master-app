<template>
  <div class="container">
    <header class="pt-3 pb-2">
      <h3 class="">災害備蓄マスタ{{ actionName }}</h3>
    </header>
    <main>
      <form>
        <!-- 商品コード・商品名 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="product-cd"
              >商品コード<span class="text-black-50">（必須）</span></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                name="product-cd"
                id="product-cd"
                placeholder="商品を選択してください"
                v-model="product.cd"
                v-validate="'required'"
                data-vv-as="商品コード"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button
                  type="submit"
                  class="btn btn-info"
                  @click.prevent="openProductSearchModal"
                >
                  選択
                </button>
              </span>
            </div>
            <div v-if="errors.has('product-cd')" class="alert-danger">
              {{ errors.first('product-cd') }}
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="product-name">商品名</label>
            <input
              type="text"
              class="form-control"
              id="product-name"
              placeholder="商品を選択してください"
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
              placeholder="商品を選択してください"
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
              placeholder="商品を選択してください"
              v-model="product.manufactureName"
              readonly
            />
          </div>
        </div>

        <!-- 数量 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="quantity"
              >数量<span class="text-black-50">（必須）</span></label
            >
            <input
              type="text"
              class="form-control"
              name="quantity"
              id="product-volume"
              v-validate="'required|numeric'"
              data-vv-as="数量"
              placeholder="数量を入力してください"
              v-model="disasterStock.quantity"
            />
            <div v-if="errors.has('quantity')" class="alert-danger">
              {{ errors.first('quantity') }}
            </div>
          </div>

          <!-- 支店コード・支店名 -->
          <div class="form-group col-md-3 px-3">
            <label for="branch-code">支店コード</label>
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="branch-code"
                placeholder="支店コードを選択してください"
                v-model="disasterStock.branchCd"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button
                  type="submit"
                  class="btn btn-info"
                  @click.prevent="openBranchSearchModal"
                >
                  選択
                </button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-3 px-3">
            <label for="branch-name">支店名</label>
            <input
              type="text"
              class="form-control"
              id="branch-name"
              placeholder="支店コードを選択してください"
              v-model="disasterStock.branchName"
              readonly
            />
          </div>
        </div>

        <!-- 備蓄保持区分・備蓄条件区分・県コード -->
        <div class="form-row mt-3">
          <div class="form-group col-md-3 px-3">
            <label for="saving-stock-kbn"
              >備蓄保持区分<span class="text-black-50">（必須）</span></label
            >
            <select
              class="form-control"
              name="saving-stock-kbn"
              v-validate="'required'"
              data-vv-as="備蓄保持区分"
              v-model="disasterStock.savingStockKbn"
            >
              <!-- v-model="searchCondition.savingStockKbn" -->
              <option value hidden></option>
              <option
                syle="color: black;"
                v-for="kbn in savingStockKbnOptions"
                :key="kbn.id"
                :value="kbn.cd"
              >
                {{ kbn.cdAndValue }}
              </option>
            </select>
            <div v-if="errors.has('saving-stock-kbn')" class="alert-danger">
              {{ errors.first('saving-stock-kbn') }}
            </div>
          </div>
          <div class="form-group col-md-3 px-3">
            <label for="stock-condition-kbn"
              >備蓄条件区分<span class="text-black-50">（必須）</span></label
            >
            <select
              class="form-control"
              name="stock-condition-kbn"
              v-validate="'required'"
              data-vv-as="備蓄条件区分"
              v-model="disasterStock.stockConditionKbn"
            >
              <option value hidden></option>
              <option
                syle="color: black;"
                v-for="kbn in stockConditionKbnOptions"
                :key="kbn.id"
                :value="kbn.cd"
              >
                {{ kbn.cdAndValue }}
              </option>
            </select>
            <div v-if="errors.has('stock-condition-kbn')" class="alert-danger">
              {{ errors.first('stock-condition-kbn') }}
            </div>
          </div>

          <div class="form-group col-md-3 px-3">
            <label for="pref-cd">県コード</label>
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="pref-cd"
                placeholder="県コードを選択してください"
                v-model="disasterStock.prefCd"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button
                  type="submit"
                  class="btn btn-info"
                  @click.prevent="openPrefSearchModal"
                >
                  選択
                </button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-3 px-3">
            <label for="pref-name">県名</label>
            <input
              type="text"
              class="form-control"
              id="pref-name"
              placeholder="県コードを選択してください"
              v-model="disasterStock.prefName"
              readonly
            />
          </div>
        </div>

        <!-- 備蓄開始日・備蓄終了日 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="stock-start-date">備蓄開始日<span class="text-black-50">（必須）</span></label>
            <input
              type="date"
              class="form-control"
              name="stock-start-date"
              id="stock-start-date"
              v-validate="'required'"
              data-vv-as="備蓄開始日"
              v-model="disasterStock.stockStartDate"
            />
            <div v-if="errors.has('stock-start-date')" class="alert-danger">
              {{ errors.first('stock-start-date') }}
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="stock-end-date">備蓄終了日<span class="text-black-50">（必須）</span></label>
            <input
              type="date"
              class="form-control"
              name="stock-end-date"
              id="stock-end-date"
              v-validate="'required'"
              data-vv-as="備蓄開始日"
              v-model="disasterStock.stockEndDate"
            />
            <div v-if="errors.has('stock-end-date')" class="alert-danger">
              {{ errors.first('stock-end-date') }}
            </div>
          </div>
        </div>

        <!-- 不足時入荷支店コード・支店名 -->
        <div class="form-row mt-3 mb-5">
          <div class="form-group col-md-6 px-3">
            <label for="reserve-branch-code"
              >不足時入荷支店コード<span class="text-black-50"
                >（必須）</span
              ></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                name="reserve-branch-code"
                id="reserve-branch-code"
                v-validate="'required'"
                data-vv-as="不足時入荷支店コード"
                placeholder="支店を選択してください"
                v-model="disasterStock.reserveBranchCd"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button
                  type="submit"
                  class="btn btn-info"
                  @click.prevent="openReserveBranchSearchModal"
                >
                  選択
                </button>
              </span>
            </div>
            <div v-if="errors.has('reserve-branch-code')" class="alert-danger">
              {{ errors.first('reserve-branch-code') }}
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="reserve-branch-name">不足時入荷支店名</label>
            <input
              type="text"
              class="form-control"
              id="reserve-branch-name"
              placeholder="支店を選択してください"
              v-model="disasterStock.reserveBranchName"
              readonly
            />
          </div>
        </div>

        <div class="input-group px-3">
          <button
            type="submit"
            class="btn btn-primary btn-lg px-5 mr-3"
            @click.prevent="createOrUpdate"
          >
            {{ actionName }}
          </button>
          <button type="submit" class="btn btn-secondary btn-lg px-5">
            戻る
          </button>
        </div>
      </form>

      <ProductSearchModal ref="productSearchModal" />
      <BranchSearchModal ref="branchSearchModal" />
      <PrefSearchModal ref="prefSearchModal" />
    </main>
  </div>
</template>

<script>
import ProductSearchModal from '@/components/ProductSearchModal';
import BranchSearchModal from '@/components/BranchSearchModal';
import PrefSearchModal from '@/components/PrefSearchModal';
import { api } from '../services/api.service';
export default {
  name: 'DisasterStockForm',
  components: {
    ProductSearchModal,
    BranchSearchModal,
    PrefSearchModal
  },
  props: {
    actionName: {
      type: String,
      required: true
    }
  },
  disasterStock: {
    type: Object,
    required: true,
    default: () => {
      return {
        id: '',
        productCd: '',
        savingStockKbn: '',
        PrefCd: '',
        branchCd: '',
        quantity: '',
        StockStartDate: '',
        StockEndDate: '',
        ReserveBranchCd: '',
        StockConditionKbn: '',
        Version: ''
      };
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
      savingStockKbnOptions: [],
      stockConditionKbnOptions: [],
      disasterStock: {
        id: '',
        productCd: '',
        savingStockKbn: '',
        prefCd: '',
        branchCd: '',
        branchName: '',
        quantity: '',
        stockStartDate: '',
        stockEndDate: '',
        reserveBranchCd: '',
        reserveBranchName: '',
        stockConditionKbn: '',
        version: ''
      }
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  methods: {
    async createOrUpdate() {
      this.disasterStock.productCd = this.product.cd;
      this.disasterStock.savingStockKbn = String(
        this.disasterStock.savingStockKbn
      );
      this.disasterStock.stockConditionKbn = String(
        this.disasterStock.stockConditionKbn
      );

      this.$validator.validateAll().then(isValid => {
        if (!isValid) return;
      });

      this.$emit('createOrUpdate', this.disasterStock);
    },
    openProductSearchModal: function() {
      this.$refs.productSearchModal.openModal();
    },
    openBranchSearchModal: function() {
      const operationDataType = 'branch';
      this.$refs.branchSearchModal.openModal(operationDataType);
    },
    openReserveBranchSearchModal: function() {
      const operationDataType = 'reserveBranch';
      this.$refs.branchSearchModal.openModal(operationDataType);
    },
    openPrefSearchModal: function() {
      this.$refs.prefSearchModal.openModal();
    },
    async genSavingStockOptions() {
      this.savingStockKbnOptions = [];
      this.savingStockKbns = await api.getSavingStockKbn();

      for (const [, v] of this.savingStockKbns.entries()) {
        this.savingStockKbnOptions.push({
          id: v['id'],
          cd: v['cd'],
          cdAndValue: `${v['cd']}: ${v['value']}`
        });
      }
    },
    async genStockConditionOptions() {
      this.stockConditionKbnOptions = [];
      this.stockConditionKbns = await api.getStockConditionKbn();

      for (const [, v] of this.stockConditionKbns.entries()) {
        this.stockConditionKbnOptions.push({
          id: v['id'],
          cd: v['cd'],
          cdAndValue: `${v['cd']}: ${v['value']}`
        });
      }
    },
    async loadEditTargetData() {
      const disasterStockJson = await api.getDisasterStockById(
        this.$route.params.id
      );

      this.product = {};
      this.product = await api.getProductByCd(disasterStockJson.productCd);
      const manufacture = await api.getManufactureByCd(
        this.product.manufactureCd
      );
      this.product.manufactureName = manufacture.name;

      let savingStockKbn = await api.getSavingStockKbnByCd(
        disasterStockJson.savingStockKbn
      );
      let pref = await api.getPrefByCd(disasterStockJson.prefCd);
      let branch = await api.getBranchByCd(disasterStockJson.branchCd);
      let reserveBranch = await api.getBranchByCd(
        disasterStockJson.reserveBranchCd
      );
      const stockConditionKbn = await api.getStockConditionKbnByCd(
        disasterStockJson.stockConditionKbn
      );

      this.disasterStock = {};
      this.disasterStock = {
        id: disasterStockJson.id,
        productCd: this.product.cd,
        productName: this.product.name,
        savingStockKbn: savingStockKbn.cd,
        savingStockCdValue: savingStockKbn.cd + ': ' + savingStockKbn.value,
        prefCd: pref.cd,
        prefName: pref.name,
        branchCd: branch.cd,
        branchName: branch.name,
        quantity: disasterStockJson.quantity,
        stockStartDate: this.parseDateToString(
          new Date(disasterStockJson.stockStartDate)
        ),
        stockEndDate: this.parseDateToString(new Date(disasterStockJson.stockEndDate)),
        reserveBranchCd: reserveBranch.cd,
        reserveBranchName: reserveBranch.name + '支店',
        stockConditionKbn: stockConditionKbn.cd,
        stockConditionCdValue:
          stockConditionKbn.cd + ': ' + stockConditionKbn.value
      };
      console.log(disasterStockJson.stockStartDate);
      console.log(this.disasterStock.stockStartDate);
    },
    parseDateToString: function(date) {
      // var date = new Date();
      var dateString = new Date(
        date.getTime() - date.getTimezoneOffset() * 60000
      )
        .toISOString()
        .split('T')[0];
      return dateString;
    }
  },
  mounted() {
    if (!this.currentUser) {
      this.$router.push('/login');
    }

    this.genSavingStockOptions();
    this.genStockConditionOptions();

    if (this.actionName == '編集') this.loadEditTargetData();
  }
};
</script>
