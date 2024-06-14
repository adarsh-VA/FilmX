import axios from 'axios';

export default{
    namespaced:true,
    state(){
      return{
          producers:[]
      }
    },
    mutations: {
      setProducers(state,payload){
          state.producers=payload;
      }
    },
    actions:{
      async loadProducers(context){
          const response = await axios.get('https://localhost:44314/producers');
          context.commit('setProducers',response.data);
      },
      async addProducer(context,payload){
        const producerResponse = await axios.post('https://localhost:44314/producers',payload);
        console.log(producerResponse);
      }
    },
    getters:{
      allProducers(state){
          return state.producers;
      }
    }
}