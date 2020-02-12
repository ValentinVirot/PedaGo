<template>
    <div class="trial">
        <div class="row m-0 py-4">
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <h5 class="m-0 text-white"> Éditer un joueur </h5>
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Nom </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="text" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Nom du joueur" v-model="player.LastName">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Prénom </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="text" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Prénom du joueur" v-model="player.FirstName">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Adresse email </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="email" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Adresse email du joueur" v-model="player.Email">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Pseudonyme </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="text" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Pseudonyme du joueur" v-model="player.Login">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Mot de passe </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="password" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Mot de passe du joueur"  v-model="player.Password">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-3 col-2 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <h5 class="m-0 text-white"> Image de profil (URL) </h5>
            </div>
            <div class="col-4 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <input type="text" class="placeholder-white col-8 p-0 form-control border-0 text-white sc-dark-light" placeholder="Image de profil du joueur"  v-model="player.Picture">
            </div>
        </div>
        <div class="row m-0 pt-5">
            <div class="offset-10 col-1 p-0 d-flex justify-content-center align-items-center py-3 sc-item">
                <v-btn class="btn-lg sc-pink text-white mt-5" v-on:click="EditPlayer()" type="button">Éditer le joueur !</v-btn>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    name: 'editplayer',
    data: function() {
        return {
            player: this.$route.params.player
        }
    },
    methods: {
        async EditPlayer(){
            await this.$editPlayer(this.player);
            this.$router.push('/players');
            location.reload();
        }
    }
}
</script>