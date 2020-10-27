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
  name: 'DisasterStockEdit',
  components: {
    'disaster-stock-form': DisasterStockForm
  },
  data() {
    return {
      actionName: '編集'
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    }
  },
  methods: {
    async createOrUpdate(disasterStock) {
      disasterStock.createdAt = new Date();
      disasterStock.updatedAt = new Date();
      const resDisasterStock = await api.updateDisasterStock(disasterStock);
      this.flash('disasterStock updated', 'success');

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
