<template>
    <div class="row mt-5 ml-12 mr-12 sc-kaki">
        <div class="col-1 text-center">
            <v-avatar size="70">
                <img v-if="player.Picture != '' && player.Picture != null" v-bind:src="player.Picture">
                <img v-else src="https://www.acep.org/static/globalassets/resources/images/edda_images/genericM250.jpg">
            </v-avatar>
        </div>

        <div class="col mt-auto mb-auto text-center">
            <h5 class="text-white"> {{ player.FirstName + ' ' + player.LastName + ' (' + player.Login + ')' }}</h5>
        </div>

        <div class="col-1 mt-auto mb-auto">
            <router-link :to="{ name: 'editplayer', params: { player } }"><v-icon color="white" class="mr-3">mdi-account-edit-outline</v-icon></router-link>
            <button v-on:click="overlay = !overlay"><v-icon color="white">mdi-trash-can-outline</v-icon></button>
        </div>

        <v-overlay :value="overlay">
             <div class="row sc-dark d-flex align-items-center">
                <div class="col">
                    <h5>Voulez-vous vraiment supprimer ce joueur ?</h5>
                </div>
                <div class="col">
                    <v-btn @click="DeletePlayer()">Confirmer</v-btn>
                </div>
                <div class="col">
                    <v-btn @click="overlay=false">Non</v-btn>
                </div>
             </div>
        </v-overlay>
    </div>
</template>

<script>

export default {
    name: 'player',
    methods: {
        DeletePlayer() {
            this.$deletePlayer(this.player);
        }
    },
    data: () => ({
        overlay: false
    }),
    props: [
        'player'
    ]  
}
</script>