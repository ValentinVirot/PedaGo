<template>
    <div class="trial">
        <div class="row m-0 py-4 bg-white">
            <div class="col-3 sc-dark-light p-0 d-flex justify-content-center align-items-center py-3">
                <v-icon color="white">mdi-gamepad-variant</v-icon>
                <h5 class="m-0 ml-3 text-white"> Jeux </h5>
            </div>
            <router-link class="offset-6 col-3 nav-link text-white d-flex justify-content-center py-3 sc-dark-light " to="/creategame">
                <h5 class="m-0"> Créer un Jeu </h5>
            </router-link>
        </div>
        <div class="row m-0 pt-5 d-flex justify-content-center bg-white">
            <h4 class="text-dark">Jeux en cours</h4>
        </div>
        <div v-for="play of plays" v-bind:key="play.Id">
            <GameInProgress v-bind:game="play" class="bg-white py-3"/>
        </div>
        <div class="row m-0 pt-5 d-flex justify-content-center sc-dark">
            <h4 class="text-white">Mes Jeux</h4>
        </div>
        <div class="sc-dark" v-for="game in games" v-bind:key="game.Id">
            <router-link :to="{ name: 'startgame', params: { game } }" class="nav-link">
                <Game v-bind:game="game" class="py-3"/>
            </router-link>
        </div>
    </div>
</template>

<script>

import Game from '@/components/Game';
import GameInProgress from '@/components/GameInProgress';


export default {
    name: 'games',
    components : {
        Game,
        GameInProgress
    },
    created: async function(){
        this.allgames = await this.$getGames();
        this.allgames.forEach((game) =>
        {
            if (game.Plays.StartDate != null)
            {
                this.plays.push(game);
            }
            else
            {
                this.games.push(game);
            }
        })
    },
    data : function(){
        return {
            games :[],
            plays: [],          
            allgames :[]
        }
    }
}
</script>