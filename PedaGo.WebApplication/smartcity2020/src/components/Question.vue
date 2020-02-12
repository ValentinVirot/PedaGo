<template>
    <div>
        <div class="row m-0 pt-3">
            <div class="col-3 sc-dark-light rounded d-flex justify-content-center">
                <input class="text-white" v-model="trial.Libelle" placeholder="Question"/>
            </div>
        </div>
        <div class="row mt-3 m-0 pb-3">
            <div class="col-10">
                <input class="text-white w-100"  v-model="trial.GoodAnswer.Libelle" placeholder="Réponse"/>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: [
        'trial'
    ]
}
</script>