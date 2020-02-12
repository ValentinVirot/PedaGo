<template>
    <div class="trial">
        <div class="row m-0 py-4">
            <Map v-on:createStep="CreationStep"/>
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="text" class="col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Nom du Parcours" v-model="Route.Name">
            </div>
            <div class="offset-6 col-3 sc-dark-light">
                <div>
                    <div class="row d-flex justify-content-center align-items-center mt-4">
                        <div class="sc-pink col-10 d-flex justify-content-center align-items-center py-3 sc-item">
                            <h5 class="text-white m-0">Steps</h5>
                        </div>
                    </div>
                    <div v-for="Step in ListSteps" v-bind:key="ListSteps.indexOf(Step)" class="row d-flex justify-content-center align-items-center mt-4">
                        <Steps v-bind:Step="Step" class="py-3"/>
                    </div>
                    <div class="row d-flex justify-content-center align-items-center mt-4">
                        <div class="col-5 d-flex justify-content-center align-items-center py-3 sc-item">
                            <v-bottom-sheet v-model="sheet" persistent>
                                <template v-slot:activator="{ on }">
                                    <v-btn color="sc-kaki" dark v-on="on">
                                        Créer une Etape
                                    </v-btn>
                                </template>
                                <v-sheet class="text-center offset-3 col-6" height="300px">
                                    <v-btn class="mt-3" color="error" @click="sheet = !sheet">fermer</v-btn>
                                    <div class="row m-0">
                                        <input type="text" v-model="NameStep" class="offset-1 col-3 my-5 form-control border-0 text-white sc-dark-light" placeholder="Nom de l'Step" />
                                        <input type="text" v-model="AdresseStep" class="offset-1 col-6 my-5 form-control border-0 text-white sc-dark-light" placeholder="Adresse, Nom, ou Coordonnées" />
                                    </div>
                                    <div class="row m-1">
                                        <textarea v-model="DecriptionStep" class="form-control" placeholder="Description"></textarea>
                                    </div> 
                                    <div class="row m-1">
                                        <input type="text" v-model="ImageStep" class="form-control" placeholder="URL de l'image"/>
                                    </div>                                  
                                    <v-btn class="sc-pink text-white" @click="CreateStep(), sheet =!sheet, DecriptionStep='', AdresseStep='', NameStep='', ValidationStep=''">Créer</v-btn>
                                </v-sheet>
                            </v-bottom-sheet>
                        </div>
                    </div>
                    <div class="row m-0 d-flex justify-content-center">
                        <v-btn color="sc-kaki" dark @click="CreateRoute()">
                            Valider le parcours
                        </v-btn>
                    </div>
                </div>
            </div>
        </div>   
    </div>
</template>

<script>

import Steps from '@/components/Steps'
import Map from '@/components/Map'
import axios from 'axios'

export default {
    name: 'createroute',
    components: {
        Steps,
        Map
    },
    data : function(){
        return {
            Route:{
                Name:'',
                Handicap:true,
                Distance:1,
                OrganizerId:1,
                Routesteps:[]
            },
            ListSteps:[],
            sheet : false,
            StepCreate : null,
            stepFromMap : false,
            lnglat : null,
            NameStep: '',
            AdresseStep: '',
            DecriptionStep: '',
            ImageStep: ''
        }
    },
    methods: {
        CreateStep(){ 
            if (this.NameStep == null || this.AdresseStep == null || this.NameStep == '' || this.AdresseStep == ''){
                this.break;
            }
            else {
                var Step = {Name:'',Lat:'',Lng:'',Description:'',Validation:''};
                Step.Name = this.NameStep;
                Step.Description = this.DecriptionStep;
                Step.Validation = this.ValidationStep;
                if(this.stepFromMap==false){
                    axios({
                        method: 'post',
                        url: 'https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf6248dd4a54ad0d9b4ba8b8bc1df57e85b59f&text='+this.AdresseStep
                    }).then(response => {
                        this.$children[0].AddMarker(response.data['bbox'][1],response.data['bbox'][0])
                        Step.Lng = response.data['bbox'][0];
                        Step.Lat = response.data['bbox'][1];
                    });
                }
                else{
                    Step.Lng = this.lnglat['lng'];
                    Step.Lat = this.lnglat['lat'];
                }
                this.ListSteps.push(Step);
                this.StepCreate = Step;
                this.lnglat = null;
                this.stepFromMap = false;
            }    
        },
        CreationStep(lngLat)
        {
            this.lnglat = lngLat;
            this.stepFromMap=true;
            this.sheet = true;
        },
        CreateRoute()
        {
            for(let i = 0;i<this.ListSteps.length;i++)
            {
                this.Route.Routesteps.push({Step : this.ListSteps[i], Order : i });
            }

            this.$addRoute(this.Route);
        }
    } 
}
</script>
