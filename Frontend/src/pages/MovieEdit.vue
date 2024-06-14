<template>
    <v-container>
      <v-btn fab fixed left color="black" class="white--text" to="/movies"><v-icon>mdi-arrow-left</v-icon></v-btn>
      <movie-form card-title="Edit Movie Details" :movie-object="editDetails" @movie-data="editMovie"></movie-form>
      <loading-component v-if="loadingStatus"></loading-component>
    </v-container>
</template>

<script>
  import MovieForm from '@/components/MovieForm.vue';
  import LoadingComponent from '../components/LoadingComponent.vue';

  export default {
    data(){
        return {
            testData:'testing data',
            loadingStatus:false
        };
    },
    components:{
      MovieForm,
      LoadingComponent
    },
    methods:{
      async editMovie(data,upload,oldLink,movieId){
        this.loadingStatus=true;
        const details={
          movieDetails:data,
          uploadStatus:upload,
          oldPoster:oldLink,
          id:movieId
        }
        await this.$store.dispatch('movies/editMovie',details);
        this.loadingStatus=false;
        this.$router.push('/movies');
        // console.log(data,uploadStatus,oldPoster);
      }
    },
    computed:{
        editDetails(){
            return this.$store.getters['movies/editingMovieDetails'];
        }
    }
  }
</script>