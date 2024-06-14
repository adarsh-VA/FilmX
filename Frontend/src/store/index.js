import moviesModule from './modules/movies.js';
import producersModule from './modules/producers.js';
import genresModule from './modules/genres.js';
import actorsModule from './modules/actors.js';


const storeConfig={
  modules:{
    movies:moviesModule,
    actors:actorsModule,
    genres:genresModule,
    producers:producersModule
  }
}

export default storeConfig;