<template>
  <div class="container">
    <disaster-stock-form
      @createOrUpdate="createOrUpdate"
      :actionName="this.actionName"
    ></disaster-stock-form>
  </div>
</template>

<script>
import { api } from '../services/api.service';
import DisasterStockForm from '../components/DisasterStockForm.vue';
export default {
  name: 'DisasterStockRegister',
  components: {
    'disaster-stock-form': DisasterStockForm
  },
  data() {
    return {
      actionName: '登録'
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  methods: {
    async createOrUpdate(disasterStock) {
      disasterStock.id = 0;
      disasterStock.createdAt = new Date();
      disasterStock.updatedAt = new Date();
      const resDisasterStock = await api.createDisasterStock(disasterStock);
      this.flash('disasterStock created', 'success');

      this.$router
        .push({
          name: 'disaster-stock-search',
          params: { message: resDisasterStock.message }
        })
        .catch(() => {});
    }
  },
  mounted() {
    if (!this.currentUser) {
      this.$router.push('/login');
    }
  }
};
</script>
