<template>
    <div>
        <div class="row m-0 py-4">
            <div class="col-4 p-0 py-1 bg-white d-flex justify-content-center">
                <h5 class="m-0"> {{step.Name}} </h5>
            </div>    
        </div>
        <div v-if="step.Missions.length != 0">
            <div class="row m-0">
                <div class="offset-1 col-2 p-0 py-1 sc-kaki d-flex justify-content-center">
                    <h5 class="m-0"> {{ step.Missions[0].Name }} </h5>
                </div>    
            </div>
            <div class="row m-0">
                <div class="offset-1 col-10 border border-kaki">
                    <div v-if="step.Missions[0].Trials.length != 0">
                        <div  v-for="trial in step.Missions[0].Trials" v-bind:key="step.Missions[0].Trials.indexOf(trial)">
                            <Quizz class="py-3" v-if="trial.Type.Description == 'Quizz'" v-bind:trial="trial"></Quizz>
                            <QrCode class="py-3"  v-if="trial.Type.Description == 'QrCode'" v-bind:trial="trial"></QrCode>
                            <Question class="py-3"  v-if="trial.Type.Description == 'Question'" v-bind:trial="trial"></Question>
                        </div>
                    </div>
                    <div class="offset-1 col-5 py-3 sc-item">
                        <v-bottom-sheet v-model="sheet" persistent>
                            <template v-slot:activator="{ on }">
                                <v-btn color="sc-kaki" dark v-on="on">
                                    Ajouter une Epreuve
                                </v-btn>
                            </template>
                            <v-sheet class="text-center offset-3 col-6" height="150px">
                                <v-btn class="mt-3" color="error" @click="sheet = !sheet">fermer</v-btn>
                                <div class="row m-0 py-4 d-flex justify-content-center align-items-center">
                                    <v-btn class="col-2 sc-dark-light text-white" @click="AddQuizz(), sheet = !sheet">Quizz </v-btn>
                                    <v-btn class="offset-1 col-2 sc-dark-light text-white" @click="AddQrCode(), sheet = !sheet">QrCode </v-btn>
                                    <v-btn class="offset-1 col-2 sc-dark-light text-white" @click="AddQuestion(), sheet = !sheet">Question </v-btn>
                                </div>
                            </v-sheet>
                        </v-bottom-sheet>
                    </div> 
                </div>
            </div>  
        </div>           
    </div>
</template>


<script>
import Quizz from '@/components/Quizz';
import QrCode from '@/components/QrCode';
import Question from '@/components/Question';

export default {
    name: 'details',
    components: {
        Quizz,
        QrCode,
        Question
    },
    props: [
        'step'
    ],
    data : function(){
        return {
            sheet : false,
        }
    },
    watch(){
        this.trials = this.step
    },
    methods: {
        AddQuizz(){
            var quizz = {Type: {Description: 'Quizz'}, Libelle: '', GoodAnswer: {}, Answers: []};
            this.step.Missions[0].Trials.push(quizz);
        },
        AddQrCode(){
            var qrcode = {Type: {Description: 'QrCode'}, Libelle: '', QrCode: ''};
            this.step.Missions[0].Trials.push(qrcode);
        },
        AddQuestion(){
            var question = {Type: {Description: 'Question'}, Libelle: '', GoodAnswer: {}};
            this.step.Missions[0].Trials.push(question);
        }
    }
}
</script>