import axios from 'axios'
import Vue from 'vue'

export default {
    methods: {
        getAPIToken() {
            var form = new FormData();
            form.set('Username', 'ValentinVirot');
            form.set('Password', 'password');

            axios({
                method: 'post',
                url: Vue.$baseApiUrl + '/auth/gettoken',
                data: form
            }).then(response => {
                Vue.$token = response.data.token
            }).catch(function(err) {
                alert(err)
            });
        },

        getImmersiveReaderCredentials() {
            axios({
                method: 'get',
                url: Vue.$baseApiUrl + '/auth/getirtoken',
                headers: {
                    'Authorization': `Bearer ${this.token}`
                }
            }).then(response => {
                Vue.$irToken = response.data.token;
                Vue.$irSubdomain = response.data.subdomain;
            }).catch(function(err) {
                alert(err)
            });
        },

        getPlayers() {
            axios({
                method: 'get',
                url: 'http://localhost:55429/api/getPlayersByOrganizerId',
                headers: {
                    'Authorization': `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE1ODExNjQ4NjMsImlzcyI6InZhbGVudGludmlyb3QuZnIiLCJhdWQiOiJ2YWxlbnRpbnZpcm90LmZyIn0.VpMx34qy4XMcBs0ijDvukZWm869LXz-5qmGmwM0XF5A`
                }
            }).then(response => {
                Vue.$players = response.data;
            }).catch(function(err) {
                alert(err)
            });
        }
    }
};