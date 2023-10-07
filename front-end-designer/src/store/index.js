import { createStore } from 'vuex'

export default createStore({
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
        getUser(state){
            return state.user;
        },
        getDomain(state){
            return state.domain;
        },
        getAreas(state){
            return state.domain.areas;
        },
        getBackground(state){
            return state.domain.background;
        },
        getDesign(state){
            return state.domain.design;
        },
        getAddress(state){
            return state.domain.address;
        },
        getUsername(state){
            return state.user.name;
        },
        getDomainName(state){
            return state.domain.name;
        }
    },
    //async operations
    actions: {

    }
})