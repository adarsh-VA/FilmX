<template>
    <v-card width="280px" class="pa-2 mx-auto card">
        <img v-if="posterUrl" :src="require(`@/assets/imgs/${posterUrl}`)"   alt="Card image" height="300px" width="100%">
        <div v-else class="text-center d-flex" style="height: 300px;align-items: center;justify-content: center;">
          <h2>No Image</h2>
        </div>
        <v-card-title class="pa-2">
          {{ name }}
        </v-card-title>
        <v-card-text class="pa-2">
          {{ plot?plot:'No movie Plot' }}
        </v-card-text>
        <v-card-actions class="pa-2">
          
          <!-- dailog for Movie Details -->
          <v-dialog
            v-model="dialog"
            width="500"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="info" plain class="pa-0" v-bind="attrs"
                v-on="on">Explore <i class="fa fa-arrow-right"></i></v-btn>
            </template>
          
            <v-card class="pa-2">
                <v-img v-if="posterUrl" :src="require(`@/assets/imgs/${posterUrl}`)" height="300px" contain class="dailog-img mb-3"></v-img>
                <div v-else class="text-center d-flex" style="height: 300px;align-items: center;justify-content: center;">
                  <h2>No Image</h2>
                </div>
                <hr>
                <v-card-title>
                  {{ name }}
                </v-card-title> 
                <v-card-text class="pb-0 black--text" style="overflow-y: scroll; height: 200px;">
                  <p><b>Year Of Release: </b> {{ YOR }}</p> 


                  <p><b>Actors: </b> {{ loadActors }}</p> 
                
              
                  <p><b>Producer: </b> {{ producer.name }}</p> 
                
              
                  <p><b>Genre: </b> {{ loadGenres }}</p> 
                
                
                  <p><b>Plot: </b>{{ plot }}</p> 
                </v-card-text>
            
              <v-divider></v-divider>
            
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  text
                  @click="dialog = false"
                >
                  Close
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-spacer></v-spacer>
          <div>
              <router-link :to="editLink"><i class="fa-regular fa-pen-to-square mr-1"></i></router-link>
              <a class="red--text"><i class="fa-regular fa-trash-can" @click="deleteMovie"></i></a>
          </div>
        </v-card-actions>
      </v-card>
</template>

<script>
export default{
    props:['id','name','actors','genres','plot','producer','YOR','posterUrl'],
    data(){
      return{
        dialog:false,
      }
    },
    computed:{
        loadActors(){
          var actors = this.actors;
          var len = actors.length;
          var result = '';
          for(var i=0;i<len-1;i++){
            result += actors[i].name + ', '
          }
          result += actors[len-1].name;
          return result;
        },
        loadGenres(){
          var genres = this.genres;
          var len = genres.length;
          var result = '';
          for(var i=0;i<len-1;i++){
            result += genres[i].name + ', '
          }
          result += genres[len-1].name;
          return result;
        },
        editLink(){
          return `movies/edit/${this.id}`;
        }
    },
    methods:{
      deleteMovie(){
        console.log("deleted");
        const data = {
          id:this.id,
          poster:this.posterUrl
        }

        var confirm = window.confirm("Are You Sure you want to delete?");
        if(confirm)
          this.$store.dispatch('movies/deleteMovie',data);
      }
    }
}
</script>

<style scoped>

.card{
    backdrop-filter: blur(5px);
    background-color: rgba(255, 255, 255, 0.726);
}

.card:hover{
    transition: transform 0.3s;
    box-shadow: 0 0px 10px 2px #212121;
}

.v-card__text{
  height: 50px;
  overflow: hidden;
}

</style>