import axios from 'axios';

const apiCall = {
    install(Vue) {
        const baseUrl = 'http://localhost:55429';
        Vue.prototype.$getToken = async function(){
            var form = new FormData();
            form.set('Username', 'raphaeldelcroix');
            form.set('Password', 'password');
            return await axios({
                method: 'post',
                url: baseUrl + '/auth/gettoken',
                data: form
            });            
        },
        Vue.prototype.$getRoutes = async function()
        {
            var token = await this.$getToken();
            return await axios({
                method: 'get',
                url: baseUrl + '/api/getRoutes',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                }
            }).then(response=>{
                return response.data;
            });
        },
        Vue.prototype.$addRoute = async function(route)
        {
            var token = await this.$getToken();
            axios({
                method: 'post',
                url: baseUrl + '/api/addRoute',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                },
                data: route
            }); 
        },
        Vue.prototype.$getPlayersByOrganizerId = async function(id){
            var token = await this.$getToken();
            return await axios({
                method: 'get',
                url: baseUrl + `/api/getPlayersByOrganizerId?id=${id}`,
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                }
            }).then(response=>{
                return response.data;
            });
        }
        Vue.prototype.$addPlayer = async function(player)
        {
            var token = await this.$getToken();
            axios({
                method: 'post',
                url: baseUrl + '/api/addPlayer',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                },
                data: player
            });
        },
        Vue.prototype.$editPlayer = async function(player)
        {
            var token = await this.$getToken();
            axios({
                method: 'post',
                url: baseUrl + '/api/editPlayer',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                },
                data: player
            });
        },
        Vue.prototype.$deletePlayer = async function(player)
        {
            var token = await this.$getToken();
            axios({
                method: 'post',
                url: baseUrl + '/api/deletePlayer',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                },
                data: player
            });
            location.reload();
        },
        Vue.prototype.$getGames = async function()
        {
            var token = await this.$getToken();
            return await axios({
                method: 'get',
                url: Vue.$baseApiUrl + '/api/getGames',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                }
            }).then(reponse =>{
                return reponse.data;
            });
        },
        Vue.prototype.$getImmersiveReaderTokens = async function() {
            var token = await this.$getToken();
            return await axios({
                method: 'get',
                url: Vue.$baseApiUrl + '/auth/getirtoken',
                headers: {
                    'Authorization': `Bearer ${token.data.token}`
                }
            }).then(response => {
                Vue.$irToken = response.data.token;
                Vue.$irSubdomain = response.data.subdomain;
            }).catch(function(err) {
                alert(err)
            });
        }
    }
  };
  
  export default apiCall;