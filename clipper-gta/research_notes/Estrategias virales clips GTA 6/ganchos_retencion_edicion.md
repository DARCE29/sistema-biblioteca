# Hooks and Retention Editing for Short-Form Vertical Gaming/Streamer Clips (TikTok, YouTube Shorts)

> Research date: 2026-11-11. Method note: WebFetch was blocked in this session (opus.pro, reap.video and autoclip.dev failed DNS through the sandbox network policy), so findings come from search-engine result summaries of the cited pages, not from full-page reads. Most numeric specs come from **vendor blogs** (OpusClip, Eklipse, Blitzcut, CapCut, ClipSpeed), not from peer-reviewed studies or official platform documentation. Each item is labeled: **[OFFICIAL]** platform source, **[DATA]** a published dataset with stated sample, **[VENDOR]** a tool-company claim or how-to with no published method, **[ANECDOTAL]**.

## 1. What makes the first 1–3 seconds work (and hook templates for gaming clips)

### Takeaway
Viewers decide whether to stay in the first 1–3 seconds. The best-supported tactics are to open on the action (start just before the peak, or cold-open on the payoff), state what the clip is about in about 3 s (TikTok's official window for the hook is the first 6 s), and add a short, large text overlay for clips that need context. Numeric "hook rate" benchmarks are third-party heuristics, not platform numbers.

### Cited Findings
- [OFFICIAL] TikTok's guide for ad creatives says to "prioritize your hook in the first 6 seconds to boost engagement and increase watch time". It also recommends captions or text overlays for context, 9:16 at 720p or higher, and keeping text inside safe zones. — [TikTok Ads Help: Creative best practices for performance ads](https://ads.tiktok.com/resources/help/article/creative-best-practices)
- [OFFICIAL] TikTok's business blog says 90% of ad-recall impact happens in the first 6 seconds, and that creative attributes that get people to read "increase view time, drive recall". (Ad context, not organic.) — [TikTok for Business blog: Creative best practices](https://ads.tiktok.com/business/en-US/blog/creative-best-practices-top-performing-ads)
- [OFFICIAL] TikTok's SMB playbook says videos "should always include sound" to capture attention. — [TikTok Creative Made Simple (PDF)](https://ads.tiktok.com/business/library/SMB_Creative_Playbook_External.pdf)
- [VENDOR] Third-party benchmarks for retention at the 3-second mark conflict: ≥50%, ≥65%, or 70–85% count as "good" depending on the source. Motion puts the average hook rate for ads at about 25–30%, with top ads at 40–50%. No official TikTok number was found. — [nestscale](https://nestscale.com/blog/increase-tiktok-hook-rate.html); [billo](https://billo.app/blog/hook-rate-to-hold-rate); [dev.to Hook Engineering 2026](https://dev.to/bulkdl/hook-engineering-the-science-of-the-first-3-seconds-in-short-form-video-2026-2jp9)
- [VENDOR/DATA] In OpusClip's 13.5M-clip analysis, "product/outcome showcase" hooks in the first 3 s averaged 6,037 views, 2× the lowest-ranked hook type (n = 34,635 clips). "Shock/surprise" openers are the most common hook in high-performing clips. — [OpusClip: Anatomy of a Viral TikTok 2026](https://www.opus.pro/blog/anatomy-of-a-viral-tiktok-2026); [OpusClip research: editing guide](https://www.opus.pro/research/video-editing-guide-short-form)
- [VENDOR] Eklipse names three hook types for gaming clips: (1) an **action hook**, which starts at the moment right before the peak; (2) a **text hook** for clips that need context, an overlay from second 0 to 1 that sets up the moment ("if context is essential, use a 1-second text overlay"); and (3) a reaction-led hook. — [Eklipse: stream hook strategy, first two seconds](https://blog.eklipse.gg/beginner-guide-2/stream-hook-strategy-first-two-seconds.html)
- [VENDOR] Eklipse's caption-length advice: hook line about 40–60 characters, full caption about 100–140 characters, and if it takes more than about 5 s to read, cut it. — [Eklipse: TikTok caption length for gaming clips](https://blog.eklipse.gg/basic-knowledge/tiktok-caption-length-gaming-clips-guide.html)
- [VENDOR] For gaming Shorts, "the first 2 seconds must grab attention" and the clip needs a clear payoff. — [OpusClip: YouTube Gaming 8.8B hours](https://www.opus.pro/blog/youtube-gaming-8-8b-hours-ai-clipping-helps-creators-win)
- [VENDOR] Viral GTA clips share a short setup, a visible reaction, and an ending right after the payoff. — summarized via [Eklipse viral gaming clips](https://blog.eklipse.gg/beginner-guide-2/viral-gaming-clips.html) / [autoclip 10 hook types](https://autoclip.dev/blog/10-types-of-viral-clip-hooks)
- [VENDOR] Numbered or listicle titles ("3 times [streamer] broke character") are said to outperform un-numbered phrasing in TikTok search. — [autoclip: 8 clip title patterns](https://autoclip.dev/blog/8-clip-titles-that-rank-on-tiktok-search)
- [ANECDOTAL/LEAKED] The leaked "How to Succeed in MrBeast Production" document (published by Rosanna Pansino in August 2024; authenticity was corroborated by other ex-employees but never officially confirmed) calls the first minute "the most important minute" because that is when people click off most. It is about long-form, so it applies to shorts only in spirit (front-load the payoff and promise). — [Tubefilter](https://www.tubefilter.com/2024/09/17/mrbeast-internal-production-guide-leaked-key-points/amp/); [Passionfruit](https://passionfru.it/?p=81151)
- [OFFICIAL] YouTube Studio's **"Viewed vs. Swiped Away"** metric ("how many chose to view") is the hook metric for Shorts. YouTube publishes no threshold. Third parties suggest 70–79% viewed is mid-range and 80% or more is strong (unofficial). — [YouTube Help](https://support.google.com/youtube/answer/12220281); [1of10](https://1of10.com/blog/youtube-shorts-analytics/); [Creator Essentials](https://www.creatoressentials.com/glossary/viewed-vs-swiped-away/)

### Inferences
- **Script rule:** pick the peak timestamp (kill, crash, scream, laugh, cop chase ending) from audio energy and Whisper keywords, then start the clip 1–3 s before the peak. Alternatively, cold-open with the 1–2 s peak, flash a "⏪" or "rewind" effect, and play the setup → peak again. Never start with more than about 1 s of calm gameplay.
- **Text hook:** at most 1 line, about 40–60 characters (about 3–7 words), visible from frame 0 for about 1.5–3 s, centered in the upper-middle of the frame. Gaming-oriented templates (not individually validated, so treat as a starting set). EN/ES pairs:
  - "He did NOT expect this 💀" / "No se esperaba ESTO 💀"
  - "Wait for the ending…" / "Espera al final…"
  - "[Streamer] broke GTA 6 in 10 seconds" / "[Streamer] rompió GTA 6 en 10 segundos"
  - "This is why cops hate him 😭" / "Por esto la poli lo odia 😭"
  - "Worst heist in GTA 6 history" / "El peor atraco de la historia de GTA 6"
  - "3 times [streamer] raged in GTA 6" / "3 veces que [streamer] perdió la cabeza en GTA 6"
  - "POV: you're [streamer]'s getaway driver" / "POV: eres el conductor de [streamer]"
- **Spanish:** auto-translate hook templates and use Whisper language detection to choose the template language. Keep Spanish hooks in the same character budget (Spanish runs about 15–25% longer than English, so shorten).

### Gaps
- No official TikTok or YouTube number for "good" 3-second retention. All benchmarks are third-party.
- No source with data comparing "wait for it" against other phrasings. No data on Spanish-language hook performance.
- TikTok's "state the proposition within 3 s" guideline is attributed to TikTok by secondary sites but was not verified on an official page.

## 2. Retention editing: cut frequency, punch-in zooms, screen shake, silence removal, speed ramps

### Takeaway
Remove dead air aggressively but with padding. Add a visual change (cut, zoom, caption pop, overlay) every few seconds. Use punch-in zooms and impact effects sparingly, only on peaks. Precise "cuts every N seconds" figures are creator heuristics with no controlled data. For gaming clips the gameplay already carries motion, so over-editing is a documented risk.

### Cited Findings
- [VENDOR] One editing guide recommends jump cuts about every 5–10 seconds to keep momentum. — [socialrevver short-form editing](https://www.socialrevver.com/blog/short-form-video-editing) (as summarized in search; exact attribution among the gaming-editing results is uncertain)
- [VENDOR] Reaction inserts should last at most about 1–3 s, and impact effects should be used sparingly. — [Eklipse: make gaming clips dynamic](https://eklipse.gg/help/how-do-i-make-my-gaming-clips-more-dynamic-and-engaging/)
- [VENDOR] Zoom or punch-in is "one of the most used effects and a bit overused". One source advises skipping punch-ins on clips under 15 s, where they feel rushed. Gaming zooms fall apart if the source is heavily compressed (upscale artifacts). — [autoclip: punch-in zoom](https://autoclip.dev/blog/how-to-use-punch-in-zoom-effect); [faceless.so micro-editing](https://faceless.so/blog/micro-editing-tactics-to-boost-video-watch-time); [veo3ai gaming edit](https://www.veo3ai.io/blog/gaming-video-edit)
- [VENDOR] SFX and overlays should be supportive: "the viewer hears the gameplay, understands the reaction, and only notices the effects when they sharpen the moment". Overlays that compete with the clip make it harder to watch. — [Eklipse esports clips](https://eklipse.gg/help/how-can-i-make-my-esports-clips-more-appealing-to-viewers)
- [VENDOR] Silence-removal settings for Shorts: threshold −30 to −35 dB, minimum silence 0.25–0.4 s, padding 0.05–0.1 s on each side. More aggressive settings clip word endings. Other sources: −40 dB as a default for speech, and −30 dB catches quiet speech while −50 dB catches only true dead air. Removing every breath sounds robotic. — [Blitzcut: remove silence from Shorts](https://blitzcutai.com/blog/how-to-remove-silence-youtube-shorts); [premierecopilot](https://www.premierecopilot.com/en/blog/remove-silence-premiere-pro-workflow)
- [DATA/tool docs] auto-editor (open source) defaults: `--margin 0.2s` padding, audio threshold `0.04` linear amplitude (about −28 dB), and dB units are accepted (e.g. `audio:-19dB`). — [auto-editor GitHub](https://github.com/wyattblue/auto-editor)
- [VENDOR] Seamless-loop troubleshooting: trim 2–4 frames from the end and retest. — [CapCut: seamless loop videos](https://www.capcut.com/create/seamless-loop-videos-continuity-techniques)

### Inferences
- **Suggested default parameters for the ffmpeg/Whisper pipeline (derived from the ranges above, not validated):**
  - Silence cut: `silencedetect=noise=-35dB:d=0.35`, keep 0.1 s padding before and after speech. Do **not** cut silence where game audio is loud (explosions, music). Detect on a voice-isolated or mic track if available, otherwise use Whisper word timestamps (cut gaps > 0.4 s between words, unless the RMS of the game audio is high).
  - Pattern interrupt: ensure some visual change (cut, zoom step, caption pop, emoji, SFX) at least every 2–4 s. This is tighter than the vendor's 5–10 s jump-cut heuristic, because word-by-word captions already provide micro-changes.
  - Punch-in zoom: 1.10–1.25× scale (ease 4–8 frames) on peak words or volume spikes, at most about one every 3–5 s, and skip it on clips under 15 s. Use `zoompan` or `scale`+`crop` with interpolation. Avoid over 1.3× on compressed Twitch sources (1080p60 at 6 Mbps degrades).
  - Screen shake: 6–12 frames, amplitude about 10–20 px, only on impacts (gunshot, crash, vine-boom moments). No source gave numbers; these are craft defaults.
  - Speed ramps: speed up driving or travel segments (1.5–2×, audio pitched or muted) instead of cutting, and use slow-mo (0.5×) only on the payoff frame. No sourced data.
- Gaming clips have strong motion already. Lean on cuts that remove downtime rather than stacking effects.

### Gaps
- No controlled study found for optimal cut frequency, zoom percentage, or shake amplitude on short-form video. All are craft heuristics.
- No sourced data on speed ramps or screen shake.

## 3. Animated captions: word-by-word vs phrase, size, position/safe zones, colors, emoji

### Takeaway
Captions are close to universal on high-performing clips: OpusClip finds about 80% of viral clips are captioned and about 79% use animation. Animation is a usage correlation, not a proven causal lift. The de-facto style is "Hormozi/karaoke": bold all-caps sans-serif, thick black outline, 2–4 words per group, the active word highlighted in yellow or green and slightly larger. Place captions in the middle or upper-middle of the frame. Avoid the bottom roughly 20–25% (UI and description) and the right roughly 120–140 px (action buttons).

### Cited Findings
- [VENDOR/DATA] In OpusClip's 13.5M-clip analysis, 80.2% of viral clips use captions and 78.6% use caption animation. Static captions are "falling out of favor". These are usage shares, not measured lifts. — [OpusClip: Anatomy of a Viral TikTok 2026](https://www.opus.pro/blog/anatomy-of-a-viral-tiktok-2026); [OpusClip caption strategy research](https://www.opus.pro/research/best-caption-strategy-short-form)
- [VENDOR] About 70–85% of short-form video is watched with sound off or low (unsourced estimate). Word-by-word captions lift completion by about 15% on educational content (method not published). — via [Blitzcut: animated vs static captions](https://blitzcutai.com/blog/animated-captions-vs-static-captions)
- [DATA, older 2019] Verizon Media/Publicis: 80% of respondents said they were more likely to finish a video when captions were available. This covers captions generally, not animated ones. — cited via [Blitzcut](https://blitzcutai.com/blog/animated-captions-vs-static-captions) (flagged as pre-2025)
- [VENDOR] For gaming clips, gameplay audio is the part people mute first, so captions must carry commentary and humor. — [Eklipse](https://eklipse.gg/help/what-are-the-best-practices-for-using-text-captions-and-popular-memes-to-increase-viewer-engagement/)
- [VENDOR] Hormozi-style caption specs: Montserrat Black 900, The Bold Font, or Anton. Premiere preset size 85, with variants at 70, 85 and 100. A 1080×1920 guide suggests 40–60 px (likely too small; see inference). Groups of 2–3, 2–4, or up to 4–6 words per line depending on the source. Highlight yellow #F7C204 or #FDE047, or green, with the emphasized word enlarged 2–4 pt. All caps, black outline, the current word highlighted while previous words stay white, and 1–2 emojis per 15 s. — [vidpros](https://vidpros.com/learn-secrets-hormozi-style-video-captions/); [submagic](https://www.submagic.co/blog/how-to-make-alex-hormozi-captions); [lilys.ai CapCut guide](https://lilys.ai/notes/en/create-youtube-shorts-20260115/capcut-hormozi-captions); [fluxnote](https://fluxnote.io/guides/hormozi-style-captions-tutorial); [Blitzcut caption colors](https://blitzcutai.com/blog/best-caption-colors-tiktok)
- [VENDOR] Safe zones at 1080×1920 (no official pixel spec; sources disagree):
  - TikTok: about 130 px top and about 480 px bottom clear (usable about 870×1310), or a 900×1492 center with a 320 px bottom block. TikTok added an "Add to Playlist" button at bottom-right in January 2026, widening the right dead zone by about 20 px.
  - YouTube Shorts: usable about 888×1500 or 984×1500 centered. Keep captions at least 120 px from the top and at least 300 px above the bottom. The bottom 15–20% holds the title, buttons and description, and putting captions there is "the most common mistake".
  - Captions that clear TikTok's bottom band may still be covered on Shorts.
  — [ClipSpeed: Shorts size 2026](https://www.clipspeed.ai/blog/youtube-shorts-size.html); [adaptlypost safe zones 2026](https://adaptlypost.com/blog/social-media-safe-zones-2026-complete-guide); [Blitzcut caption placement](https://blitzcutai.com/blog/best-caption-placement-short-form-video); [reap.video safe zones](https://reap.video/blog/short-form-video-safe-zones); [Blitzcut caption size](https://blitzcutai.com/blog/best-caption-size-youtube-shorts-2026)

### Inferences
- **Recommended ASS/libass spec for the script (synthesized from the sources above):** font Montserrat Black or Anton, all caps. Size about 80–100 px at 1080×1920 (the 40–60 px figure reads small on phones; Premiere's "85" preset is in the same ballpark). Outline 6–8 px black plus a soft shadow. 2–4 words per group, maximum 1 line (2 at most), maximum about 18 characters per line. Active word in yellow #FDE047 (or green #22C55E for "good" moments, red for deaths) and scaled 110–120% with a 3–5 frame pop. Inactive words white.
- **Vertical position:** baseline at about y = 1150–1300 px (≈60–68% down), which clears TikTok's about 480 px bottom and Shorts' 300–380 px bottom. Keep x within 90–990 px (right margin ≥ 140 px for the button column). With a facecam-top / gameplay-bottom layout, put captions on the seam between the two panels (about y 700–900) so they cover neither face nor key gameplay.
- Whisper `word_timestamps=True` gives the per-word timing needed for karaoke highlighting. Group by pauses greater than 0.3 s or punctuation, with a maximum of 4 words.
- **Emoji:** at most 1–2 per 15 s, attached to keywords (💀 😭 🔥 🚓 💰). Map Spanish keywords too ("muerto", "policía", "dinero").
- Censor or mask profanity if needed for monetization. This is not researched here.

### Gaps
- No independent A/B test isolating animated vs static captions, or word-by-word vs phrase, in short-form gaming clips.
- No official TikTok or YouTube pixel safe-zone spec. All figures are third-party measurements.

## 4. Sound design: SFX, background music under game audio, volume levels, meme sounds

### Takeaway
There is no data-backed source on vine boom or meme SFX performance. Guidance is "supportive, sparse, on peaks". For levels, target about −14 LUFS integrated for the master (TikTok's normalization is estimated, not published) and sit any background music about 15–20 dB (LU) under speech, with ducking. For streamer clips, the streamer's voice and the game audio come first; music is optional and quiet.

### Cited Findings
- [OFFICIAL] TikTok: always include sound. — [TikTok SMB playbook](https://ads.tiktok.com/business/library/SMB_Creative_Playbook_External.pdf)
- [VENDOR] TikTok is said to normalize to about −14 LUFS, or −14 to −16 LUFS; it is "not published". TikTok and Reels heavily compress audio between swipes. — [dj-master TikTok BGM loudness](https://dj-master-web.vercel.app/en/blog/tiktok-bgm-mastering-en); [mixinggpt 2026](https://mixinggpt.com/blog/mixing-mastering-streaming-loudness-2026); [OpenClip loudness standard](https://openclip.app/learn/loudness-standard)
- [VENDOR] Music under dialogue: 10–20 dB lower than speech; or an absolute −30 to −35 dB; or formula-based, e.g. narration −18 LUFS with 20 LU separation. Use ducking with attack and release. — [shortsfast](https://shortsfast.com/blog/mix-background-music-under-narration-without-masking-speech/); [hollyland CapCut volume](https://www.hollyland.com/blog/topics/best-volume-for-background-music-in-capcut); [OpenClip ducking](https://openclip.app/learn/audio-ducking)
- [VENDOR] Subtle sound design "helps reset attention, emphasize transitions"; overlays that compete with the clip hurt it. — [Eklipse](https://eklipse.gg/help/how-can-i-make-my-esports-clips-more-appealing-to-viewers); [faceless.so](https://faceless.so/blog/micro-editing-tactics-to-boost-video-watch-time)

### Inferences
- **Pipeline defaults:**
  - Master: `loudnorm=I=-14:TP=-1.0:LRA=11`.
  - Music (if used): about −20 to −25 LU below the voice, with `sidechaincompress` ducking (attack about 20 ms, release about 250–400 ms).
  - SFX: peaks at about −6 to −10 dBFS before the master, at most about 1 per 3–5 s. Whoosh on cuts and zooms (150–300 ms), boom or vine-boom on punchlines and impacts, ding on text pop-ins.
- Copyright: GTA 6's in-game radio and score may trigger Content ID or TikTok muting. Consider ducking or replacing in-game licensed music. Not researched; worth a separate check.
- Meme SFX (vine boom, bruh, "oh no") fit the gaming and streamer culture, but there is no performance data. Treat them as style choices and A/B test.

### Gaps
- No data source found on vine boom or meme SFX impact, or on SFX density.
- No official TikTok or YouTube loudness target.

## 5. Optimal duration per platform (2025–2026) and loop techniques

### Takeaway
There is a tension between goals. Short clips (15–30 s) get the highest engagement rate and completion, while longer clips (60–180 s) get more reach and watch time on TikTok. For streamer and gaming moments the data supports about 15–45 s for single-moment clips (OpusClip's top-signal bucket is 30–45 s), and 60–90 s or more only for compilations or story clips. YouTube Shorts now allows up to 3 min, and since March 31, 2025 every replay counts as a view, which makes seamless loops directly valuable for view counts.

### Cited Findings
- [DATA] Buffer (March 2025, 1.1M TikToks): videos over 60 s got 43.2% more reach and 63.8% more watch time than shorter videos. Buffer calls 30–60 s a balance of reach and engagement. — [Buffer: Longer TikToks get more views](https://buffer.com/resources/longer-tiktoks-get-more-views-data/)
- [DATA] Socialinsider 2026: videos under 30 s win on engagement, while views climb with length, with the biggest jump at 120–180 s. 15–30 s has the highest engagement rate. — [Socialinsider: TikTok vs Reels vs Shorts 2026](https://www.socialinsider.io/blog/tiktok-vs-reels-vs-shorts/); [Socialinsider video statistics](https://www.socialinsider.io/social-media-benchmarks/social-media-video-statistics)
- [DATA] A Sociable study reported by Marketing Dive found that longer clips are gaining traction on TikTok. — [Marketing Dive](https://www.marketingdive.com/news/research-tiktok-longer-videos-get-more-reach/743067/)
- [VENDOR/DATA] OpusClip lists "30–45 s length" among its top signals; this comes from the public-web sample, not the full 13.5M set. — [OpusClip Anatomy 2026](https://www.opus.pro/blog/anatomy-of-a-viral-tiktok-2026)
- [VENDOR] A gaming-specific guide suggests 15–30 s clips. — [Eklipse viral gaming clips](https://blog.eklipse.gg/beginner-guide-2/viral-gaming-clips.html)
- [OFFICIAL/news] YouTube Shorts went up to 3 minutes for square or vertical uploads from October 15, 2024 (previously 60 s). — [TechCrunch-style coverage: 9to5Google](https://9to5google.com/2024/10/03/youtube-shorts-3-minutes/); [Social Media Today](https://www.socialmediatoday.com/news/youtube-expands-3-minute-shorts-to-all-users/736967/)
- [OFFICIAL/news] From March 31, 2025, a Shorts view is counted every time a Short starts or replays, with no minimum watch time. YPP monetization still uses "engaged views". — [TechCrunch](https://techcrunch.com/2025/03/26/youtube-is-changing-how-youtube-shorts-views-are-counted); [Sprout Social support](https://support.sproutsocial.com/hc/en-us/articles/35874991211533-YouTube-Shorts-View-Count-Update-March-2025)
- [ANECDOTAL] Creators reported drops in Shorts viewership after a September (2025) algorithm change. — [PPC Land](https://ppc.land/youtube-creators-report-drops-in-shorts-viewership-after-september-algorithm-change/)
- [VENDOR] A loop works when "the final frame, movement, sound, and on-screen context lead naturally back to the first frame". If it doesn't, trim 2–4 frames from the end. Another technique repeats one idea within the first 3 s. No A/B data. — [CapCut seamless loops](https://www.capcut.com/create/seamless-loop-videos-continuity-techniques); [CapCut looping narrative hooks](https://www.capcut.com/create/looping-narrative-hooks-watch-time)
- [UNVERIFIED] Claim that loop-friendly Shorts "roughly double engaged views". — [gyre.pro](https://gyre.pro/blog/youtube-shorts-view-count-update-impact-strategy-what-to-do-next)

### Inferences
- **Script targets:** single-moment clip 15–35 s (hard cap 59 s). Compilation ("3 times…") 45–90 s. End within 0.5–1.5 s after the payoff or reaction. Do not add an outro.
- **Loop technique for the script:**
  - (a) End on a frame or sentence that leads into the opening hook, for example a cold-open structure where the end is the moment just before the peak shown at the start.
  - (b) Cut the last line mid-sentence so it completes with the first line.
  - (c) Match the audio level and music beat at the cut, with a 2–4 frame trim tolerance and no fade-out to black.

### Gaps
- No 2025–2026 data specific to gaming clip length, or comparing TikTok and Shorts lengths for gaming.
- No controlled data on how much loops lift completion or rewatch.

## 6. Progress bars, on-screen title persistence, CTAs, end screens

### Takeaway
Evidence here is weak. No controlled test of progress bars on Shorts or TikTok was found; the claims come from vendors of player bars for long-form or sales video. Persistent titles and "part 2" or follow CTAs are common practice but unmeasured. Endings should be abrupt (right after the payoff) to protect completion and loops.

### Cited Findings
- [VENDOR] "Dummy" progress bars are sold to "create the perception that the video is reaching its end"; this is sales-video marketing, not short-form data. — [Panda Video](https://www.pandavideo.com/features/dummy-progress-bar); [Vidalytics](https://vidalytics.com/reb-seeking)
- [ANECDOTAL] A flashy custom bar reportedly hurt retention on long-form, and a subtle one restored it. — [domalberto custom progress bar (opinion)](https://ava.ead.domalberto.edu.br/custom-progress-bar-youtube)
- [VENDOR] Ending right after the payoff is a shared trait of viral GTA clips. — [Eklipse viral gaming clips](https://blog.eklipse.gg/beginner-guide-2/viral-gaming-clips.html)
- [VENDOR] OpusClip's other signals: 8–12 hashtags mixing niche and generic tags, posting at 7am or 4pm ET on weekdays, and 77.8% of top clips use a third-person perspective in the storyline. — [OpusClip Anatomy 2026](https://www.opus.pro/blog/anatomy-of-a-viral-tiktok-2026)

### Inferences
- A progress bar is optional and should be A/B tested. If used, make it thin (6–10 px), low-contrast, top edge (y≈0–10), because the platforms' own scrubbers sit at the bottom.
- Persistent title: a short headline in a top band (y≈140–300) for the whole clip helps viewers who join mid-loop. The hook text can shrink into this band after 2–3 s. Unmeasured.
- CTA: avoid a spoken or visual end-card CTA (it breaks loops). If needed, use a small "Parte 2 👀" or "Sigue para más" overlay only on series content.

### Gaps
- No data on progress-bar effects in TikTok or Shorts, persistent titles, or CTA effects on short-form retention.
- Nothing found from YouTube Creator Insider with numbers on these elements.

## 7. Layout for streamer clips (9:16 conversion)

### Takeaway
The standard is a stack: facecam on top, gameplay below, with gameplay getting the larger share (about 40/60 or one-third / two-thirds). Center-cropping 16:9 gameplay loses about half the width, so choose crop focus deliberately or use a blurred-background fill.

### Cited Findings
- [VENDOR] Facecam on top and gameplay below, with the facecam in the upper third and gameplay in the lower two-thirds. One guide lists a 60/40 split favoring the larger area for gameplay. A 50/50 split is mainly for two-person content. — [Eklipse vertical mistakes](https://blog.eklipse.gg/basic-knowledge/common-vertical-video-mistakes-streamers-fix.html); [ClipSpeed vertical guide](https://clipspeed.ai/blog/vertical-video-editing-guide.html); [Vizard facecam highlights](https://agent.vizard.ai/how-to/cut-gaming-highlights-that-keep-your-facecam-in-shot.html)
- [VENDOR] Zoom-cropping 16:9 to 9:16 removes about half the width. The alternative is to center the original with a blurred fill above and below. — [ClipSpeed](https://clipspeed.ai/blog/vertical-video-editing-guide.html)
- [ANECDOTAL] Facecams pixelate when zoomed in vertical clips. — [Reddit r/Twitch](https://reddit.birdcat.cafe/r/Twitch/comments/1il9byn/why_is_my_webcam_blurry_in_vertical_clips)

### Inferences
- ffmpeg layout: top 1080×640 (facecam crop scaled), bottom 1080×1280 (gameplay crop at about 1.0–1.2× of a 16:9 center or action region). Captions go on the seam. For GTA, keep the minimap or HUD off-frame or crop it unless it's relevant.

### Gaps
- No data comparing layouts (stacked vs full gameplay vs blurred fill) on retention.
