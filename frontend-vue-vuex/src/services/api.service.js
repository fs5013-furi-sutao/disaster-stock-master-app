import axios from 'axios';
import Vue from 'vue';
import VueFlashMessage from 'vue-flash-message';
import 'vue-flash-message/dist/vue-flash-message.min.css';
import authHeader from './auth-header';

Vue.use(VueFlashMessage, {
  messageOptions: {
    timeout: 3000,
    pauseOnInteract: true
  }
});

const vm = new Vue();
const baseURL = 'http://localhost:4000/api/v1/';

const handleError = fn => (...params) =>
  fn(...params).catch(error => {
    vm.flash(`${error.response.status}: ${error.response.statusText}`, 'error');
  });

export const api = {
  // Products
  getProductById: handleError(async id => {
    const res = await axios.get(baseURL + 'MstProducts/id/' + id, {
      headers: authHeader()
    });
    return res.data;
  }),
  getProductByCd: handleError(async cd => {
    const res = await axios.get(baseURL + 'MstProducts/cd/' + cd, {
      headers: authHeader()
    });
    return res.data;
  }),
  getProductsByName: handleError(async name => {
    const res = await axios.get(baseURL + 'MstProducts/name/' + name, {
      headers: authHeader()
    });
    return res.data;
  }),

  // Manufactures
  getManufactureByCd: handleError(async cd => {
    const res = await axios.get(baseURL + 'MstManufactures/cd/' + cd, {
      headers: authHeader()
    });
    return res.data;
  }),

  // Prefs
  getPrefByCd: handleError(async cd => {
    const res = await axios.get(baseURL + 'MstPrefs/cd/' + cd, {
      headers: authHeader()
    });
    return res.data;
  }),
  getPrefsByName: handleError(async name => {
    const res = await axios.get(baseURL + 'MstPrefs/name/' + name, {
      headers: authHeader()
    });
    return res.data;
  }),

  // Branches
  getBranchesByName: handleError(async name => {
    const res = await axios.get(baseURL + 'MstBranches/name/' + name, {
      headers: authHeader()
    });
    return res.data;
  }),
  getBranchByCd: handleError(async cd => {
    const res = await axios.get(baseURL + 'MstBranches/cd/' + cd, {
      headers: authHeader()
    });
    return res.data;
  }),

  // Kbns
  getSavingStockKbn: handleError(async () => {
    const res = await axios.get(baseURL + 'MstKbns/kbn/saving_stock_kbn', {
      headers: authHeader()
    });
    return res.data;
  }),
  getSavingStockKbnByCd: handleError(async cd => {
    const res = await axios.get(
      baseURL + 'MstKbns/kbn/saving_stock_kbn/cd/' + cd,
      {
        headers: authHeader()
      }
    );
    return res.data;
  }),

  getStockConditionKbn: handleError(async () => {
    const res = await axios.get(baseURL + 'MstKbns/kbn/stock_condition_kbn', {
      headers: authHeader()
    });
    return res.data;
  }),
  getStockConditionKbnByCd: handleError(async cd => {
    const res = await axios.get(
      baseURL + 'MstKbns/kbn/stock_condition_kbn/cd/' + cd,
      {
        headers: authHeader()
      }
    );
    return res.data;
  }),

  // DisasterStocks
  createDisasterStock: handleError(async payload => {
    console.log('payload=');
    console.log(payload);
    console.log(new Date());

    const record = {
      id: 0,
      productCd: payload.productCd,
      savingStockKbn: String(payload.savingStockKbn),
      prefCd: payload.prefCd,
      branchCd: payload.branchCd,
      quantity: Number(payload.quantity),
      stockStartDate: payload.stockStartDate,
      stockEndDate: payload.stockEndDate,
      reserveBranchCd: payload.reserveBranchCd,
      stockConditionKbn: String(payload.stockConditionKbn),
      version: 1,
      createdAt: new Date(),
      createdUserId: 1,
      updatedAt: new Date(),
      updatedUserId: 1
    };

    const res = await axios.post(
      baseURL + 'MstDisasterStocks/register',
      record
    );
    console.log('res=');
    console.log(res);
    return res.data;
  }),
  updateDisasterStock: handleError(async payload => {
    console.log('payload=');
    console.log(payload);
    console.log(new Date());

    const record = {
      id: payload.id,
      productCd: payload.productCd,
      savingStockKbn: String(payload.savingStockKbn),
      prefCd: payload.prefCd,
      branchCd: payload.branchCd,
      quantity: Number(payload.quantity),
      stockStartDate: payload.stockStartDate,
      stockEndDate: payload.stockEndDate,
      reserveBranchCd: payload.reserveBranchCd,
      stockConditionKbn: String(payload.stockConditionKbn),
      version: 1,
      createdAt: new Date(),
      createdUserId: 1,
      updatedAt: new Date(),
      updatedUserId: 1
    };

    const res = await axios.put(
      baseURL + 'MstDisasterStocks/update/' + payload.id,
      record
    );
    console.log('res=');
    console.log(res);
    return res.data;
  }),
  getDisasterStockById: handleError(async id => {
    const res = await axios.get(
      baseURL + 'MstDisasterStocks/id/' + id,
      {
        headers: authHeader()
      }
    );
    return res.data;
  }),
  getDisasterStocksBySearchConditions: handleError(async searchCondition => {
    const res = await axios.get(baseURL + 'MstDisasterStocks/conditions', {
      params: {
        productCd: searchCondition.productCd,
        savingStockKbn: searchCondition.savingStockKbn,
        stockStartDate: searchCondition.stockStartDate,
        stockEndDate: searchCondition.stockEndDate
      },
      headers: authHeader()
    });
    return res.data;
  })
};
