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
            <label for="product-code"
              >商品コード<span class="text-black-50">（必須）</span></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="product-code"
                placeholder="商品を選択してください"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button type="submit" class="btn btn-info">選択</button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="product-name">商品名</label>
            <input
              type="text"
              class="form-control"
              id="product-name"
              placeholder="商品を選択してください"
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
              readonly
            />
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="product-manufacture">メーカー名</label>
            <input
              type="password"
              class="form-control"
              id="product-manufacture"
              placeholder="商品を選択してください"
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
            <select class="form-control" id="pref-cd" name="pref-cd">
              <option value="1">1</option>
              <option value="2" selected="selected">2</option>
              <option value="3">3</option>
            </select>
          </div>
          <div class="form-group col-md-3 px-3">
            <label for="stock-condition-kbn"
              >備蓄条件区分<span class="text-black-50">（必須）</span></label
            >
            <select class="form-control" id="pref-cd" name="pref-cd">
              <option value="1">1</option>
              <option value="2" selected="selected">2</option>
              <option value="3">3</option>
            </select>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="pref-cd">県コード</label>
            <select class="form-control" id="pref-cd" name="pref-cd">
              <option value="1">1</option>
              <option value="2" selected="selected">2</option>
              <option value="3">3</option>
            </select>
          </div>
        </div>

        <!-- 支店コード・支店名 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="branch-code">支店コード</label>
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="branch-code"
                placeholder="支店を選択してください"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button type="submit" class="btn btn-info">選択</button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="branch-name">支店名</label>
            <input
              type="text"
              class="form-control"
              id="branch-name"
              placeholder="支店を選択してください"
              readonly
            />
          </div>
        </div>

        <!-- 備蓄開始日・備蓄終了日 -->
        <div class="form-row mt-3">
          <div class="form-group col-md-6 px-3">
            <label for="stock-start-date">備蓄開始日</label>
            <input
              type="date"
              class="form-control"
              id="stock-start-date"
              placeholder="日付を選択・入力してください"
            />
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="stock-end-date">備蓄終了日</label>
            <input
              type="date"
              class="form-control"
              id="stock-end-date"
              placeholder="商品を選択してください"
            />
          </div>
        </div>

        <!-- 不足時入荷支店コード・支店名 -->
        <div class="form-row mt-3 mb-5">
          <div class="form-group col-md-6 px-3">
            <label for="branch-code"
              >不足時入荷支店コード<span class="text-black-50"
                >（必須）</span
              ></label
            >
            <div class="input-group">
              <input
                type="text"
                class="form-control"
                id="branch-code"
                placeholder="支店を選択してください"
                readonly
              />
              <span class="input-group-btn ml-2">
                <button type="submit" class="btn btn-info">選択</button>
              </span>
            </div>
          </div>
          <div class="form-group col-md-6 px-3">
            <label for="branch-name">不足時入荷支店名</label>
            <input
              type="text"
              class="form-control"
              id="branch-name"
              placeholder="支店を選択してください"
              readonly
            />
          </div>
        </div>

        <div class="input-group px-3">
          <button type="submit" class="btn btn-primary btn-lg px-5 mr-3">
            {{ actionName }}
          </button>
          <button type="submit" class="btn btn-secondary btn-lg px-5">
            戻る
          </button>
        </div>
      </form>
    </main>
  </div>
</template>

<script>
export default {
  name: 'DisasterStockForm',
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
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  mounted() {
    if (!this.currentUser) {
      this.$router.push('/login');
    }
  }
};
</script>
