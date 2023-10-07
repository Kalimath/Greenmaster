<template>
  <div id="canvas" class="w-full">
    <ErrorMessageDialog v-if="errorMessage"></ErrorMessageDialog>
    <div id="svgZoomContainer" data-zoom-on-wheel="zoom-amount: 0.01; min-scale: 0.3; max-scale: 20;" data-pan-on-drag
         :width="width+100" :height="height+100" class="svgZoomContainer">
      <svg id="svg" :width="width" :height="height" @click="">
      </svg>
    </div>
  </div>
</template>

<script>
import ErrorMessageDialog from "./ErrorMessageDialog.vue";
import {resetScale} from "svg-pan-zoom-container";
import {mapGetters} from "vuex";
import Colors from "../js/Colors.js";

export default {
  name: "EditorPane",
  components: {
    ErrorMessageDialog: ErrorMessageDialog
  },
  data() {
    return {
      errorMessage: '',
      width: 1000,
      height: 900,
      snap: null,
      areas: [],
      areaBorderColor: Colors.brown,
      areaFillColor: Colors.firebrick,
      areaStrokeOpacity: 1,
      backgroundInstance: null,
      panZoomInstance: null
    };
  },
  mounted: function () {
    const s = document.getElementById("canvas");
    s.onload = () => {
      this.snap = Snap("#svg");
      this.init();
    };
    document.body.appendChild(s);
  },
  computed:{
    ...mapGetters(["user", "username", "domainName", "address", "domain", "background"]),
    /**
     * Returns true if stored domain is empty
     */
    domainNotCreated() {
      return !this.domain.name
    },

  },
  methods: {
    /**
     * Initialises component
     */
    init() {
      this.renderSvg()
    },

    /**
     * Renders svg
     */
    renderSvg() {
      this.errorMessage = ''
      this.updateBackground()
      this.renderShapes()

    },
    /**
     * Updates the svg's background image.
     */
    updateBackground() {
      // let imageSvg = null
      try {
        if (document.getElementById("background")) {
          document.getElementById("background").remove()
        }
        this.backgroundInstance = this.areas.insertAfter(this.snap.image(this.background, 0, 0, this.width, this.height).attr({id: "background"}))
      } catch (e) {
        console.log("no background to loaded")
        console.log(e)
      }
      // return imageSvg;
    },
    /**
     * Resets zoom and panning of the svg element
     */
    resetPanZoom(){
      resetScale(document.getElementById('svgZoomContainer'))
    },
    /**
     * Adds all racks that need to be rendered to snap instance.
     * If zoneForm is active the temporary rack is added too.
     * Temporary rack is updated when changed in store
     */
    renderShapes() {
      //this.resetRacks()
      store.commit("resetForm")
    },
    /**
     * Removes rendered in 'rackGroup' (if possible)
     */
    removeRenderedShapes() {
      try {
        document.getElementById("areas")?.remove()
      } catch (e) {
        console.log(e)
      }
    }
  }
}
</script>

<style scoped>
svg {
  cursor: crosshair;
  background-size: cover;
  background-position: center;
}
svg:active{
  cursor: grab;
}
.svgZoomContainer{
  overflow: hidden;
  /*background-color: lightsteelblue;*/
}
</style>
