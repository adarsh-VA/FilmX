import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import VueRouter from 'vue-router'
import Vuex from 'vuex'
import axios from 'axios'

import routes from './router.js';
import storeConfig from './store';

Vue.config.productionTip = false


Vue.use(VueRouter);
Vue.use(Vuex);



// router.beforeRouteUpdate((to,from,next)=>{
//   if(to.name=== 'edit'){
//     console.log(this.$store.getters['movies/allMovies']);
//   }
//   next();
// });

const store = new Vuex.Store(storeConfig);

const router = new VueRouter({
  mode: 'history',
  routes // short for `routes: routes`
});

router.beforeEach(async(to,from,next)=>{
  if(to.name === 'edit'){
    await axios.get(`https://localhost:44314/movies/${to.params.id}`)
    .then((response)=>{
      store.state.movies.editMovie=response.data;
    })
    .catch((e)=>{
      console.log(e.message);
      router.push('error')
    });
    
    next();
  }
  next();
}); 

const app = new Vue({
  vuetify,
  render: h => h(App),
  router:router,
  store:store
});

app.$mount('#app');
