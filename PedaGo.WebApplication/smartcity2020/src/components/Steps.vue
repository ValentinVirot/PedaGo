<template>
    <div class="align-items-center">
    <h5 class="text-white text-center">{{Step.Name}}</h5>
    <h6 class="text-white">{{Step.Adresse}}</h6>
    </div>
</template>
<script>
export default {
    name: 'Step',
    props : [
        'Step'
    ],
    data : function(){
        return {
            Missions: [],
            sheet : false
        }
    },
    methods: {
        CreateMission(){
            var Mission ={Name: this.NameMission, Trials: []};
            this.Step.Mission = Mission;
        },
    }
}
</script>