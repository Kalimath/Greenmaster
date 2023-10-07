import * as Vue from 'vue'
import App from './App.vue'
import HeroIcon from 'vue-heroicons'
import store from "./store/index.js";

Vue.createApp(App)
    .use(store)
    .use(HeroIcon)
    .mount('#app')
