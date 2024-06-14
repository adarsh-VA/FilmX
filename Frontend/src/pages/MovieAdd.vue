<template>
    <v-container>
        <v-btn fab fixed left color="black" class="white--text" to="/movies"><v-icon>mdi-arrow-left</v-icon></v-btn>
        <movie-form card-title="Enter Movie Details" @movie-data="addMovie"></movie-form>
      <loading-component v-if="loadingStatus"></loading-component>
    </v-container>
</template>


<script>
  import MovieForm from '@/components/MovieForm.vue';
  import LoadingComponent from '../components/LoadingComponent.vue';

  export default {
    data(){
      return {
        loadingStatus:false
      }
    },
    components:{
      MovieForm,
      LoadingComponent
    },
    methods:{
      async addMovie(data){
        this.loadingStatus=true;
        await this.$store.dispatch('movies/addMovie',data);
        this.loadingStatus=false;
        this.$router.push('/movies');
      }
    }
  }
</script>