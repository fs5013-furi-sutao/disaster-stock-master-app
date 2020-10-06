<template>
  <div class="container">
    <disaster-stock-form
      @createOrUpdate="createOrUpdate"
      :actionName="this.actionName"
    ></disaster-stock-form>
  </div>
</template>

<script>
import DisasterStockForm from '../components/DisasterStockForm.vue';
export default {
  name: 'DisasterStockEdit',
  components: {
    'disaster-stock-form': DisasterStockForm
  },
  props: {
    actionName: {
      type: String,
      required: true,
      default: () => {
        return '編集';
      }
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
