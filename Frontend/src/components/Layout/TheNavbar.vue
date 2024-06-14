<template>
    <div>
        <v-app-bar
            elevation="4"
            fixed
            color=""
            id="top-navigation"
        >
            <img src="@/assets/nav-logo.png" alt="" height="40px">
            <v-spacer></v-spacer>
            <v-tabs right color="grey darken-4" class="hidden-xs-only" :hide-slider="!sliderVisibility">
                <v-tabs-slider color="grey darken-4"></v-tabs-slider>
                <v-tab to="/movies">Movies</v-tab>
                <v-tab to="/">Actors</v-tab>
                <v-tab to="/">Producers</v-tab>
            </v-tabs>
            <v-menu offset-y>
              <template v-slot:activator="{ on, attrs }">
                <!-- <v-btn
                  color="primary"
                  dark
                  v-bind="attrs"
                  v-on="on"
                >
                <v-icon>fas fa-list</v-icon>
                </v-btn> -->
                <v-app-bar-nav-icon color="grey darken-4"
                  dark
                  v-bind="attrs"
                  v-on="on"
                  class="hidden-sm-and-up"></v-app-bar-nav-icon>
              </template>
              <!-- <v-list>s
                <v-list-item>
                  <v-list-item-title to="/movies">Movies</v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>Actors</v-list-item-title>
                </v-list-item>
                <v-list-item>
                  <v-list-item-title>Producers</v-list-item-title>
                </v-list-item>
              </v-list> -->
              <v-tabs right color="grey darken-4" vertical>
                <v-tabs-slider color="grey darken-4"></v-tabs-slider>
                <v-tab to="/movies">Movies</v-tab>
                <v-tab to="/">Actors</v-tab>
                <v-tab to="/">Producers</v-tab>
               </v-tabs>
            </v-menu>
            
        </v-app-bar>
    </div>
</template>

<script>
  export default {
    computed:{
      sliderVisibility(){
        if(this.$route.path=="/movies")
          return true;
        else
          return false;
      }
    }
  }
</script>

<style scoped>
#top-navigation{
    backdrop-filter: blur(10px);
    /* background-color :rgba(249, 255, 249, 0.3); */
    background-color: rgba(247, 247, 247, 0.5);
    box-shadow: 0 3px 6px rgb(77, 83, 87);
    z-index: 2;
}
</style>