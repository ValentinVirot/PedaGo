<template>
    <div>
        <div class="row m-0">
            <div class="offset-1 col-5 d-flex justify-content-center align-items-center">
                <span v-on:click="onStepClicked()" class="text-white">{{step.Name}}</span>
            </div>
            <div class="col-5 d-flex justify-content-center align-items-center py-3 sc-item" v-if="this.step.Missions.length == 0">
                <v-bottom-sheet v-model="sheet" persistent>
                    <template v-slot:activator="{ on }">
                        <v-btn color="sc-kaki" dark v-on="on">
                            <v-icon>mdi-plus</v-icon>
                            Mission
                        </v-btn>
                    </template>
                    <v-sheet class="text-center offset-3 col-6" height="200px">
                        <v-btn class="mt-3" color="error" @click="sheet = !sheet">fermer</v-btn>
                        <div class="row m-0 d-flex justify-content-center">
                            <input type="text" v-model="nameMission" class="col-3 my-5 form-control border-0 text-white sc-dark-light" placeholder="Nom de la Mission">
                        </div>
                        <v-btn class="sc-pink text-white" @click="createMission(), sheet =!sheet, nameMission=''">Créer</v-btn>
                    </v-sheet>
                </v-bottom-sheet>
            </div>
            <div>
                <StepMission v-if="mission.Name != null" v-bind:mission="step.Missions" class="py-3"/>
            </div>
        </div>
    </div>
</template>

<script>

import StepMission from '@/components/StepMission';

export default {
    name: 'DisplayStep',
    components: {
        StepMission
    },
    props : [
        'step'
    ],
    data : function(){
        return {
            sheet : false,
            mission : Object,
            nameMission : ''
        }
    },
    methods: {
        createMission(){
            this.mission ={Name: this.nameMission, Trials: []};
            this.step.Missions.push(this.mission);
        },
        onStepClicked(){
            this.$emit('stepclicked',this.step);
        }
    }
}
</script>