

import MovieList from './pages/MovieList.vue';
import MovieAdd from './pages/MovieAdd.vue';
import NotFound from './components/NotFound.vue';
import MovieEdit from './pages/MovieEdit.vue';



    export default [
        {path:'/',redirect:'/movies'},
        {path:'/movies',component:MovieList},
        {
            name:'edit',path:'/movies/edit/:id', component:MovieEdit
        },
        {path:'/add',component:MovieAdd},
        {name:'error',path:':notFound(.*)' , component:NotFound}
    ]
