XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=Pods/Pods.xcodeproj
TARGET=VasSonic
DEPLOYMENTTARGET=8.0
NAME=VasSonic
CONFIG=Release
# SDKVERSION=11.0

all: $(NAME).framework
Pod.lock:
	pod install

$(NAME)-x86.framework:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphonesimulator -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphonesimulator/$(TARGET)/$(TARGET).framework $@

$(NAME)-arm.framework:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphoneos -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/$(TARGET)/$(TARGET).framework/ $@

$(NAME).framework: Pod.lock $(NAME)-arm.framework $(NAME)-x86.framework
	-rm -f $(NAME).framework
	-cp -r $(NAME)-arm.framework  $(NAME).framework
	lipo -create -output $(NAME).framework/$(NAME) $(NAME)-arm.framework/$(NAME) $(NAME)-x86.framework/$(NAME)

clean: 
	-rm -rf *.framework
	-rm -rf build
	-rm -rf Pods
	-rm -f Podfile.lock