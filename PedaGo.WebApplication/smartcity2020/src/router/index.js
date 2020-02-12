import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Games from '../views/Games.vue'
import Routes from '../views/Routes.vue'
import Players from '../views/Players.vue'
import CreateRoute from '../views/CreateRoute.vue'
import CreateGame from '../views/CreateGame.vue'
import CreatePlayer from '../views/CreatePlayer.vue'
import EditPlayer from '../views/EditPlayer.vue'
import NewGame from '../views/NewGame.vue'
import StartGame from '../views/StartGame.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/ir',
    name: 'ir',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "ir" */ '../views/IR.vue')
  },
  {
    path: '/games',
    name: 'games',
    component: Games
  },
  {
    path: '/routes',
    name: 'routes',
    component: Routes
  },
  {
    path: '/players',
    name: 'players',
    component: Players
  },
  {
    path: '/createroute',
    name: 'createroute',
    component: CreateRoute
  },
  {
    path: '/creategame',
    name: 'creategame',
    component: CreateGame
  },
  {
    path: '/createplayer',
    name: 'createplayer',
    component: CreatePlayer
  },
  {
    path: '/editplayer',
    name: 'editplayer',
    component: EditPlayer
  },
  {
    path: '/newgame',
    name: 'newgame',
    component: NewGame
  },
  {
    path: '/startgame',
    name: 'startgame',
    component: StartGame
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
