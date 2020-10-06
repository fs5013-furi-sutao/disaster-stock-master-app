import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
import Login from './views/Login.vue';
import Register from './views/Register.vue';

Vue.use(Router);

export const router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      meta: {
        title: null,
        desc: 'JWT 認証サンプルサイト'
      },
      component: Home
    },
    {
      path: '/home',
      meta: {
        title: '一般公開ページ',
        desc: '一般公開ページです。ログインしていないユーザも閲覧できるページです。'
      },
      component: Home
    },
    {
      path: '/login',
      meta: {
        title: 'ログイン',
        desc: 'ユーザ情報確認画面です。ログインユーザの情報を確認できます。'
      },
      component: Login
    },
    {
      path: '/register',
      meta: {
        title: 'ユーザ登録',
        desc: 'ユーザ登録画面です。新規ユーザを登録します。'
      },
      component: Register
    },
    // {
    //   path: '/profile',
    //   name: 'profile',
    //   meta: {
    //     title: 'プロフィール',
    //     desc: 'ユーザ情報確認画面です。ログインユーザの情報を確認できます。'
    //   },
    //   // lazy-loaded
    //   component: () => import('./views/Profile.vue')
    // },
    {
      path: '/disaster-stocks/search',
      name: 'disaster-stock-search',
      meta: {
        title: '災害備蓄マスタ検索一覧',
        desc: '災害備蓄マスタ検索画面です。災害備蓄マスタを確認できます。'
      },
      // lazy-loaded
      component: () => import('./views/DisasterStockSearch.vue')
    },
    {
      path: '/disaster-stocks/register',
      name: 'disaster-stock-register',
      meta: {
        title: '災害備蓄マスタ登録',
        desc: '災害備蓄マスタ登録画面です。災害備蓄マスタを登録できます。'
      },
      // lazy-loaded
      component: () => import('./views/DisasterStockRegister.vue')
    },
    {
      path: '/disaster-stocks/edit',
      name: 'disaster-stock-edit',
      meta: {
        title: '災害備蓄マスタ編集',
        desc: '災害備蓄マスタ編集画面です。災害備蓄マスタを編集できます。'
      },
      // lazy-loaded
      component: () => import('./views/DisasterStockEdit.vue')
    },
  ]
});

// router.beforeEach((to, from, next) => {
//   const publicPages = ['/login', '/register', '/home'];
//   const authRequired = !publicPages.includes(to.path);
//   const loggedIn = localStorage.getItem('user');

//   // trying to access a restricted page + not logged in
//   // redirect to login page
//   if (authRequired && !loggedIn) {
//     next('/login');
//   } else {
//     next();
//   }
// });
