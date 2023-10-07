import { createStore } from 'vuex'
import VuexPersistence from 'vuex-persist'

const vuexLocal = new VuexPersistence({
    storage: window.localStorage
})

const store = createStore({
    state() {
        return{
            user:{
                name:'Mathieu',
            },
            domain:{
                name: 'Home',
                address: 'street 27',
                areas: [],
                background: null,
                design: null
            }
        }
    },
    //sync operations
    mutations: {
        setUser(state, user){
            state.user = user;
        },
        setDomain(state, domain){
            state.domain = domain;
        }
    },
    //getters
    getters: {
        user(state){
            return state.user;
        },
        domain(state){
            return state.domain;
        },
        areas(state){
            return state.domain.areas;
        },
        background(state){
            return state.domain.background;
        },
        design(state){
            return state.domain.design;
        },
        address(state){
            return state.domain.address;
        },
        username(state){
            return state.user.name;
        },
        domainName(state){
            return state.domain.name;
        }
    },
    //async operations
    actions: {

    },
    plugins: [vuexLocal.plugin]
})

export default store;