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
  getProductsByName: handleError(async name => {
    const res = await axios.get(baseURL + 'MstProducts/name/' + name, {
      headers: authHeader()
    });
    return res.data;
  }),
  // getProductsByCd: handleError(async cd => {
  //   const res = await axios.get(baseURL + 'MstProducts/cd/' + cd, {
  //     headers: authHeader()
  //   });
  //   return res.data;
  // }),

  // Manufactures
  getManufactureByCd: handleError(async cd => {
    const res = await axios.get(baseURL + 'MstManufactures/cd/' + cd, {
      headers: authHeader()
    });
    return res.data;
  }),

  // Prefs
  // getPrefsByCd: handleError(async cd => {
  //   const res = await axios.get(baseURL + 'MstPrefs/cd/' + cd, {
  //     headers: authHeader()
  //   });
  //   return res.data;
  // }),

  // Branches
  // getBranchesByCd: handleError(async cd => {
  //   const res = await axios.get(baseURL + 'MstBranches/cd/' + cd, {
  //     headers: authHeader()
  //   });
  //   return res.data;
  // }),

  // Kbns
  getSavingStockKbn: handleError(async () => {
    const res = await axios.get(baseURL + 'MstKbns/kbn/saving_stock_kbn', {
      headers: authHeader()
    });
    return res.data;
  }),

  // DisasterStocks
  getDisasterStocksBySearchConditions: handleError(async payload => {
    const res = await axios.get(
      baseURL + 'MstDisasterStocks/conditions',
      {
        headers: authHeader()
      },
      payload
    );
    return res.data;
  })
};
