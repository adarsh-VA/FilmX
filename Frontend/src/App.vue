<!-- <template>
  <v-app>
    <v-app-bar
      app
      color="grey lighten-2"
      dark
    >
      <div class="d-flex align-center">
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
          transition="scale-transition"
          width="40"
        />

        <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
          width="100"
        />
      </div>

      <v-spacer></v-spacer>

      <v-btn
        href="https://github.com/vuetifyjs/vuetify/releases/latest"
        target="_blank"
        text
      >
        <span class="mr-2">Latest Release</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <HelloWorld/>
    </v-main>
  </v-app>
</template> -->

<template>
  <v-app>
    <the-navbar class="mb-4"></the-navbar>
    <router-view class="mt-14"></router-view>
  </v-app>
</template>

<script>
import TheNavbar from './components/Layout/TheNavbar.vue';

export default {
  name: 'App',

  components: {
    TheNavbar,
  },

  data: () => ({
    //
  }),
};
</script>


<style>
*{
  margin: 0;
  box-sizing: border-box;
}

.v-application--wrap{
    background-color: rgba(33, 47, 60 ,0.5); 
    background-image: url("./assets/background-image.jpg");
    background-size: cover;
    background-blend-mode:soft-light ;  
    background-attachment: fixed;  
    background-position: center;    
}
</style>