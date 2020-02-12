<template>
    <div id="map" class="position-absolute h-100 w-100"></div>
</template>

<script>
export default {
  name: 'Map',
  data : function(){
        return {
            GlobalMap: null
        }
    },
  mounted () {
    // import de mon package
    var mapboxgl = require('mapbox-gl/dist/mapbox-gl.js');
    // set du token pour MapBox
    mapboxgl.accessToken = 'pk.eyJ1IjoidG9vcmFhIiwiYSI6ImNrNjk0YjhpczAzcnEzbG1ndHNlaXEyZzcifQ.trLK5OoEcyMrmYqT1U4DWg';
    // Creation de la map
    var map = new mapboxgl.Map(
    {
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v10',
        center: [5.040287,47.324180],
        zoom: 13
    });
    
    this.GlobalMap = map;
    // Quand la map ce load
    // Les bind permettent de passer en paramètres le component pour pouvoir faire appel à this.$emit pour appeler l'event de création d'étape
    map.on('load', (function() {
        map.on('click', (function(e) {
            new mapboxgl.Marker().setLngLat(e.lngLat).addTo(map);
            this.$emit('createStep', e.lngLat);
        }).bind(this));
    }).bind(this));

  }, // End Mounted
methods:{
    AddMarker(lat,lng){
        var mapboxgl = require('mapbox-gl/dist/mapbox-gl.js');
        var lnglat = {lng: lng,lat: lat}
        new mapboxgl.Marker().setLngLat(lnglat).addTo(this.GlobalMap);
    }
}
}
</script>
<style scoped>
path{
    position: absolute !important;
}
</style>