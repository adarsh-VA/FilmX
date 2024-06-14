import axios from 'axios';

export default{
    namespaced:true,
    state(){
      return{
          actors:[]
      }
    },
    mutations: {
      setActors(state,payload){
          state.actors=payload;
      }
    },
    actions:{
      async loadActors(context){
          const response = await axios.get('https://localhost:44314/actors');
          context.commit('setActors',response.data);
      },
      async addActor(context,payload){
        const actorResponse = await axios.post('https://localhost:44314/actors',payload);
        console.log(actorResponse);
      }
    },
    getters:{
      allActors(state){
          return state.actors;
      }
    }
}
