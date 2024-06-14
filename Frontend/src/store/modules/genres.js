import axios from 'axios';

export default{
    namespaced:true,
    state(){
      return{
          genres:[]
      }
    },
    mutations: {
      setGenres(state,payload){
          state.genres=payload;
      }
    },
    actions:{
      async loadGenres(context){
          const response = await axios.get('https://localhost:44314/genres');
          context.commit('setGenres',response.data);
      },
      async addGenre(context,payload){
        const genreResponse = await axios.post('https://localhost:44314/genres',payload);
        console.log(genreResponse);
      }
    },
    getters:{
      allGenres(state){
          return state.genres;
      }
    }
}
