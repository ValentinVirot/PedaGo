<template>
    <div class="ir">
    <div class="row m-0">
      <div class="offset-2 col-8 text-center">
        <div class="rounded quizz-container">
          <img alt="Vue logo" src="../assets/logo.png" class="round-img mt-3 mb-3">

          <h1>Peda'Go! - <span id="ir-title" ref="ir-title">Test Immersive Reader</span></h1>

          <button v-on:click="immersiveReaderBtnOnClick()" class="immersive-reader-button btn sc-btn-mustard mt-2 mb-2">Immersive Reader </button>

          <div id="ir-content" ref="ir-content" lang="en-us">
              <p lang="fr-fr">
                  Bienvenue sur le site internet de Peda'Go! Ici, en tant qu'organisateur, vous pourrez créer des parcours,
                  ainsi que des parties par équipes, afin de découvrir la vie culturelle de la ville de Dijon !
              </p>

              <p lang="en-us">
                  Welcome on the Peda'Go website! Here, as an organizer, you will be able to create parcours, and team-based games,
                  to discover the awesome cultural life of Dijon!
              </p>

              <p lang="jp">
                  Peda'Goウェブサイトへようこそ！ ここでは、主催者として、コースやチームゲームを作成して、ディジョン市の文化生活を発見できます！
              </p>
          </div>

          <br>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as ImmersiveReader from '@microsoft/immersive-reader-sdk'
import Vue from 'vue'

export default {
    created() {
        this.GetIRTokens();
    },
    methods: {
        GetIRTokens() {
            this.$getImmersiveReaderTokens();
        },
        immersiveReaderBtnOnClick() {
            if(Vue.$irToken == '' || this.subdomain == '') {
                alert("Error while querying Azure credentials. Please try again.");
            }

            else {
                const content = {
                    title: this.$refs["ir-title"].innerHTML,
                    chunks: [{
                        content: this.$refs["ir-content"].outerHTML,
                        mimeType: "text/html"
                    }]
                };

                const options = {
                    "onExit": this.exitCallback,
                    "uiZIndex": 2000
                };

                ImmersiveReader.launchAsync(Vue.$irToken, Vue.$irSubdomain, content, options)
                    .catch(function (error) {
                        alert("Error in launching the Immersive Reader. Check the console." + error);
                    });
                }
        },

        exitCallback() {

        }
    }
}
</script>