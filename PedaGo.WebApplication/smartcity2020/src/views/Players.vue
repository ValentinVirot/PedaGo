<template>
    <div class="trial">
        <div class="row m-0 py-4">
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <h5 class="m-0 text-white">Joueurs</h5>
            </div>
            <div class="offset-6 col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <router-link class="nav-link text-white p-0" to="/createplayer">
                    <h5 class="m-0">Créer un joueur</h5>
                </router-link>
            </div>
        </div>
        <div class="row m-0 pt-5 d-flex justify-content-center">
            <h4 class="text-white">Joueurs</h4>
        </div>
        <div v-for="player in playerList" v-bind:key="player.Id">
            <Player v-bind:player="player" class="py-3"/>
        </div>
    </div>
</template>

<script>

import Player from '@/components/Player';
import Vue from 'vue'

export default {
    name: 'players',
    components: {
        Player
    },
    mounted: async function() {
        this.playerList = await this.$getPlayersByOrganizerId(Vue.$organizerId);
    },
    data: function(){
        return {
            playerList: []
        }
    }
}
</script>