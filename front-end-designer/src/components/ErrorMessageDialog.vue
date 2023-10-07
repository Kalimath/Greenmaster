<template>
  <div class="flex rounded-md bg-red-100 mt-2 text-red-500 px-2 py-1 items-center" v-if="message">
    <div class="flex-shrink-0 items-center">
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 text-red-500" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
        <path stroke-linecap="round" stroke-linejoin="round" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
      </svg>
    </div>
    <div class="ml-3">
      <h3 class="text-sm font-medium text-yellow-800">{{errorTitle}}</h3>
      <div class="mt-2 text-sm text-yellow-700">
        <p class="w-full">{{errorMessage}}</p>
      </div>
    </div>

  </div>
</template>

<script>


export default {
  name: "ErrorMessageComponent",
  props:{
    title: null,
    message: null
  },
  data(){
    return{
      errorTitle: "Something went wrong",
      errorMessage: ""
    }
  },
  mounted:function () {
    this.errorMessage = this.message
    if(this.title) this.errorTitle = this.title
  }
}
</script>

<style scoped>

</style>