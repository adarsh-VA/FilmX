<template>
    <v-container fluid>
      <router-view></router-view>
      <v-btn fab fixed right color="grey darken-4" class="white--text" to="/add"><v-icon>mdi-plus</v-icon></v-btn>
      <v-row class="mx-lg-16 mt-3">
        <v-col v-for="movie in movies" :key="movie.id" justify-center>
          <movie-item 
            :id ="movie.id"
            :name="movie.name" 
            :plot="movie.plot" 
            :actors="movie.actors" 
            :genres="movie.genres"
            :producer="movie.producer"
            :YOR="movie.yearOfRelease"
            :posterUrl="movie.coverImage"></movie-item>
        </v-col>
      </v-row>

    </v-container>
</template>

<script>
import MovieItem from '@/components/MovieItem.vue';

export default {
  components:{
    MovieItem
  },
  data(){
    return {
      // imgs:["avengers","black-widow","dune","godzilla","iron-man","john-wick","joker","jurassic-park","lord-of-the-rings","mad-max","star-war","suicide-squad","terminator","warcraft"],
    }
  },
  computed:{
    movies(){
      return this.$store.getters['movies/allMovies'];
    }
  },
  created(){
    this.$store.dispatch('movies/loadMovies');
  }

}
</script>

<style>
.v-overlay{
  backdrop-filter: blur(10px);
}
</style>