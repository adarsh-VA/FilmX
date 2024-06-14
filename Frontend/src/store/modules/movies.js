import axios from 'axios';
import { getStorage, ref, deleteObject } from "firebase/storage";
import { initializeApp } from "firebase/app";

export default{
    namespaced:true,
    state(){
      return{
          movies:[],
          editMovie:null
      }
    },
    mutations: {
      setMovies(state,payload){
          state.movies=payload;
      },
      removeMovie(state,payload){
        var idx =state.movies.findIndex(m=>m.id==payload);
        state.movies.splice(idx,1);        
      }
    },
    actions:{
      async loadMovies(context){
          const response = await axios.get('https://localhost:44314/movies');
          context.commit('setMovies',response.data);
      },
      async addMovie(context,payload){
        console.log(payload);
        if(payload.coverImage){
          const posterReponse = await axios.post('https://localhost:44314/movies/upload',payload.coverImage);
          payload.coverImage=posterReponse.data;
        }
        payload.language= "english";
        payload.profit= 0;

        console.log('upload success');


        const movieResponse = await axios.post('https://localhost:44314/movies',payload);
        console.log(movieResponse);
      },
      async deletePoster(context,link){
        console.log('entered delete function',link);
        const firebaseConfig = {
          authDomain: "vue-imdb-cac6a.appspot.com",
          // The value of `databaseURL` depends on the location of the database
          databaseURL: "https://vue-imdb-cac6a.firebaseio.com",
          projectId: "vue-imdb-cac6a",
          storageBucket: "vue-imdb-cac6a.appspot.com"
        };

        const app = initializeApp(firebaseConfig);

        const storage = getStorage(app);
        
        // Create a reference to the file to delete
        const desertRef = ref(storage,link);
        
        // Delete the file
        await deleteObject(desertRef).then(() => {
          // File deleted successfully
        }).catch(() => {
          // Uh-oh, an error occurred!
        });
      },
      async deleteMovie(context,payload){

        // deleting the image from the firebase.
        if(payload.poster)
          await context.dispatch('deletePoster',payload.poster);
        
        // delete movie from the database.
        context.commit('removeMovie',payload.id);
        const movieResponse = await axios.delete(`https://localhost:44314/movies/${payload.id}`);
        console.log(movieResponse);
      },
      async editMovie(context,payload){
        console.log(payload);
        if(payload.uploadStatus){
          if(payload.oldPoster)
            await context.dispatch('deletePoster',payload.oldPoster);
          console.log('no old poster');
          if(payload.movieDetails.coverImage){
            const posterReponse = await axios.post('https://localhost:44314/movies/upload',payload.movieDetails.coverImage);
            payload.movieDetails.coverImage=posterReponse.data;
          }
        }

        payload.movieDetails.language= "english";
        payload.movieDetails.profit= 0;

        console.log(payload.movieDetails);
        const movieResponse = await axios.put(`https://localhost:44314/movies/${payload.id}`,payload.movieDetails);
        console.log(movieResponse);

        // console.log(payload.movieDetails,payload.uploadStatus,payload.oldPoster);
      }
    },
    getters:{
      allMovies(state){
          return state.movies;
      },
      editingMovieDetails(state){
        return state.editMovie;
      }
    }
}
