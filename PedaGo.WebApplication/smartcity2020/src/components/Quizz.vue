<template>
    <div>
        <div class="row m-0">
            <div class="col-3 sc-dark-light rounded d-flex justify-content-center">
                <input class="text-white" v-model="trial.Libelle" placeholder="Question"/>
            </div>
        </div>
        <div class="row mt-3 m-0">
            <div class="col-3">
                <input class="text-white" v-model="trial.GoodAnswer.Libelle" placeholder="Bonne Réponse"/>
            </div>
            <div class="col-3">
                <input class="text-white" v-model="trial.Answers[1]" placeholder="Mauvaise Réponse"/>
            </div>
            <div class="col-3">
                <input class="text-white" v-model="trial.Answers[2]" placeholder="Mauvaise Réponse"/>
            </div>
            <div class="col-3">
                <input class="text-white" v-model="trial.Answers[3]" placeholder="Mauvaise Réponse"/>
            </div>
        </div>
        <div class="row mt-3 m-0">
            <div class="offset-10">
                 <button class="btn-lg sc-pink text-white mt-5" @click="validatedQuizz()" type="button">Valider</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: [
        'trial'
    ],
    methods: {
        validatedQuizz(){
            this.trial.Answers[0] = this.trial.GoodAnswer.Libelle;
        }
    }
}
</script>