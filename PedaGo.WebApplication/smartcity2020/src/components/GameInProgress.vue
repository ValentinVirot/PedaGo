<template>
    <div class="row m-0 pt-4">
        <div class="offset-1 col-3 sc-dark d-flex align-items-center p-0 py-4">
            <span class="m-0 ml-4 text-white"> {{ game.Route.Name }}</span>
        </div>
        <div class="col-1 sc-dark d-flex justify-content-center align-items-center p-0 py-4">
            <v-icon color="#ffffff" v-if="game.Route.Handicap == true">mdi-36px mdi-wheelchair-accessibility</v-icon>
        </div>
        <div class="col-2 sc-dark d-flex justify-content-end align-items-center p-0 py-4">
            <span class="m-0 text-white"> {{ game.CreationDate }}</span>
        </div>
        <div class="col-2 sc-dark d-flex justify-content-center align-items-center p-0 py-4">
            <span class="m-0 text-white"> {{ game.Transport.Description}} </span>
        </div>
        <div class="col-2 sc-dark d-flex justify-content-center align-items-center p-0 py-4">
        </div>
    </div>
</template>

<script>
export default {
    name : 'Game',
    props : [
        'game'
    ]
}
</script>