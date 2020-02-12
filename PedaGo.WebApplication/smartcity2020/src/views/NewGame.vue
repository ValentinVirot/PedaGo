<template>
    <div>
        <div class="row m-0 py-4 sc-row">
            <div class="col-9 ">
                <Map/>
            </div>
            <div class="col-3 sc-dark-light py-3">
                <div>
                    <div class="row d-flex justify-content-center align-items-center mt-4">
                        <div class="sc-pink col-10 d-flex justify-content-center align-items-center py-3">
                            <h5 class="text-white m-0">Etapes</h5>
                        </div>
                    </div>
                    <div v-for="RouteStep in RouteSteps" v-bind:key="RouteSteps.indexOf(RouteStep)">
                        <DisplaySteps v-on:stepclicked="stepClick" v-bind:step="RouteStep.Step" class="py-3"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row m-0">
            <Details class="col-12" v-show="detailShow == true" v-bind:step="selectedStep" />
        </div>
        <div class="row m-0">
            <div class="col-12 mb-5">
                <v-btn class="offset-1 col-10 sc-pink text-white" @click="createMission(), sheet =!sheet, nameMission=''">Créer</v-btn>
            </div>
        </div>
    </div>
</template>

<script>

import DisplaySteps from '@/components/DisplaySteps';
import Details from '@/components/Details'
import Map from '@/components/Map'

export default {
    name: 'newgame',
    components: {
        DisplaySteps,
        Details,
        Map
    },
    data : function(){
        return {
            RouteSteps: this.$route.params.route.Routesteps,
            detailShow: false,
            selectedStep : {}
        }
    },
    methods : {
        stepClick(Step){
            this.selectedStep = Step;
            this.detailShow = true;
        }
    }
}
</script>