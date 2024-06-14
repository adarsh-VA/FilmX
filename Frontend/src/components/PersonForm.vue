<template>
    <v-card class="pa-3">
        <v-card-title primary-title>
              <h2>{{formLabel}}</h2> 
        </v-card-title>
          <hr>
          <v-form
            ref="form"
            v-model="valid"
            lazy-validation
            class="pa-4"
            @submit.prevent
          >
            <v-text-field
              v-model="name"
              :rules="[v => !!v || 'Name is required']"
              label="Name"
              required
            ></v-text-field>
  
            <div v-if="formVisibility">
                <v-radio-group
                  v-model="gender"
                  mandatory
                >
                <template v-slot:label>
                  <h3>Gender:</h3>
                </template>
                    <v-row align="center">
                        <v-col>
                            <v-radio
                              label="Male"
                              value="Male"
                            ></v-radio>
                        </v-col>
                        <v-col>
                            <v-radio
                              label="Female"
                              value="Female"
                            ></v-radio>
                        </v-col>
                        <v-col>
                            <v-radio
                              label="Other"
                              value="Other"
                            ></v-radio>
                        </v-col>
                    </v-row>
                </v-radio-group>
    
                <v-menu
                  :nudge-right="40"
                  :close-on-content-click="false"
                  transition="scale-transition"
                  offset-y
                  min-width="auto"
                >
                  <template v-slot:activator="{ on, attrs }">
                    <v-text-field
                      v-model="DOB"
                      label="Date Of Birth"
                      prepend-icon="mdi-calendar"
                      readonly
                      v-bind="attrs"
                      v-on="on"
                      :rules="[v => !!v || 'Date Of Birth is required']"
                    ></v-text-field>
                  </template>
                  <v-date-picker
                    v-model="DOB"
                    @input="menu2 = false"
                  ></v-date-picker>
                </v-menu>
    
                <v-textarea
                  outlined
                  name="input-7-3"
                  label="Bio"
                  rows="3"
                  class="mt-3" 
                  :rules="[v => !!v || 'Bio is required']"
                  v-model="bio"
                ></v-textarea>
            </div>
            <div class="d-flex justify-end">
                <v-btn
                  color="red"
                  class="mr-4 mt-4"
                  @click="close"
                >
                  Close
                </v-btn>
            
                <v-btn
                  :disabled="!valid"
                  color="success"
                  class="mr-4 mt-4"
                  @click="submit"
                >
                  Save
                </v-btn>
            </div>
          </v-form> 
    </v-card>
</template>

<script>
export default{
    emits:['person-data','close-form'],
    props:['formLabel'],
    data(){
        return {
            valid: false,
            formValid:false,
            name: null,
            DOB: null,
            gender:null,
            bio:null
        }
    },
    computed:{
        formVisibility(){
            if (this.formLabel.includes("Actor")){
                return true;
            }
            else if(this.formLabel.includes("Producer")){
                return true;
            }
            else{
                return false;
            }
        }
    },
    methods:{
        check(){
            this.formValid = false
            if(
                this.name !=null 
                && this.DOB !=null
                && this.bio !=null
            ){
                this.formValid = true;
            }
        },
        close(){
            this.$emit('close-form');
        },
        submit(){
            this.$refs.form.validate();
            this.check();
            const type = this.getType();
            if(this.formValid && (type == 'actor' || type == 'producer')){
            
                const formData = new FormData();
                formData.append('file', this.poster);
                var data ={
                    name:this.name,
                    bio:this.bio,
                    dob:this.DOB,
                    gender:this.gender
                }
                this.$emit('person-data',data,type);                
            }   
            else{
                    if (this.name !=null){
                        data={
                            name : this.name
                        }
                        this.$emit('person-data',data,type);
                    }
                }
        },
        getType(){
            if (this.formLabel.includes("Actor")){
                return 'actor';
            }
            else if(this.formLabel.includes("Producer")){
                return 'producer';
            }
            else{
                return 'gender';
            }
        }
    }
}
</script>