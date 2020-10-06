<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <!-- <div class="container"> -->

      <router-link
        to="/"
        class="nav-link navbar-brand mt-0 pt-0 mb-0 pb-0 mr-0 pr-0"
      >
        {{ this.siteTitle }}
      </router-link>
      <div
        class="nav-link mt-2 pt-0 mb-0 pb-0 pr-5"
        style="color: #fff;font-family: 'Lato', sans-serif;"
      >
        Biticook
      </div>

      <div class="navbar-nav mr-auto">
        <li class="nav-item px-2">
          <router-link to="/home" class="nav-link">
            <font-awesome-icon icon="home" /><span class="px-2">トップ</span>
          </router-link>
        </li>
        <!-- <li class="nav-item">
          <router-link v-if="currentUser" to="/profile" class="nav-link">
            <font-awesome-icon icon="file" />&nbsp;プロフィール
          </router-link>
        </li> -->
        <li class="nav-item px-2">
          <router-link
            v-if="currentUser"
            to="/disaster-stocks/search"
            class="nav-link"
          >
            <font-awesome-icon icon="search" /><span class="px-2">検索</span>
          </router-link>
        </li>
        <li class="nav-item px-2">
          <router-link
            v-if="currentUser"
            to="/disaster-stocks/register"
            class="nav-link"
          >
            <font-awesome-icon icon="file" /><span class="px-2">登録</span>
          </router-link>
        </li>
      </div>

      <div v-if="!currentUser" class="navbar-nav ml-auto">
        <li class="nav-item px-2">
          <router-link to="/register" class="nav-link">
            <font-awesome-icon icon="user-plus" /><span class="px-2">登録</span>
          </router-link>
        </li>
        <li class="nav-item px-2">
          <router-link to="/login" class="nav-link">
            <font-awesome-icon icon="sign-in-alt" /><span class="px-2">ログイン</span>
          </router-link>
        </li>
      </div>

      <div v-if="currentUser" class="navbar-nav ml-auto">
        <li class="nav-item px-2">
          <router-link to="/profile" class="nav-link">
            <font-awesome-icon icon="user" />
            <span class="px-2">{{ currentUser.username }}</span>
          </router-link>
        </li>
        <li class="nav-item px-2">
          <a class="nav-link" href @click.prevent="logOut">
            <font-awesome-icon icon="sign-out-alt" /><span class="px-2">ログアウト</span>
          </a>
        </li>
      </div>
      <!-- </div> -->
    </nav>

    <div class="container">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      siteTitle: '災害備蓄マスタ管理'
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  methods: {
    logOut() {
      this.$store.dispatch('auth/logout');
      this.$router.push('/login');
    },
    createPageTitle: function(routeInstance) {
      // タイトルを設定
      if (routeInstance.meta.title) {
        const setTitle = `${routeInstance.meta.title} | ${this.siteTitle}`;
        document.title = setTitle;
      } else {
        document.title = this.siteTitle;
      }

      // メタタグdescription設定
      const setDesc = routeInstance.meta.desc ? routeInstance.meta.desc : '';

      const elem = document.querySelector("meta[name='description']");
      elem.setAttribute('content', setDesc);
    }
  },
  mounted: function() {
    var routeInstance = this.$route;
    this.createPageTitle(routeInstance);
  },
  watch: {
    $route(routeInstance, from) {
      this.createPageTitle(routeInstance);
    }
  }
};
</script>

<style>
#overlay {
  z-index: 1;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}
.modal-container {
  z-index: 2;
  width: 50%;
  padding: 1em;
  background: #fff;
  box-sizing: border-box;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
}
.modal-enter {
  opacity: 0;
}
.modal-leave-active {
  opacity: 0;
}
.modal-enter .modal-container,
.modal-leave-active .modal-container {
  transform: translateY(30px);
}
</style>
