import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueCookie from 'vue-cookie'
import vuetify from './plugins/vuetify'
import apiCall from './plugins/apiCall';
import BootstrapVue from "bootstrap-vue";

Vue.config.productionTip = false
Vue.use(VueCookie);
Vue.use(BootstrapVue);
Vue.use(apiCall);

Vue.$baseApiUrl = 'http://cent-v2-team4.westeurope.cloudapp.azure.com';
Vue.$token = ''
Vue.$irToken = '';
Vue.$irSubdomain = '';
Vue.$organizerId = 3;
Vue.$players = [];

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')